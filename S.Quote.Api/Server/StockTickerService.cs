using Microsoft.AspNetCore.Http;
using S.Quote.Api.Handler;
using S.Quote.Api.Model;
using ServerWebSocketTest.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace ServerWebSocketTest.Server
{
    public class StockTickerService
    {
        private readonly RequestDelegate _next;
        private WebSocketHandler _webSocketHandler;

        private readonly ConcurrentDictionary<string, Stock> _stocks = new ConcurrentDictionary<string, Stock>();

        private readonly double _rangePercent = 0.002;

        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(250);
        private readonly Random _updateOrNotRandom = new Random();

        private Timer _timer;
        private volatile bool _updatingStockPrices;

        private const string routePostfix = "/stocks";
        public StockTickerService(RequestDelegate next,
            WebSocketHandler webSocketHandler)
        {
            _next = next;
            _webSocketHandler = webSocketHandler;
            LoadDefaultStocks();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            if (!IsWebSocket(context))
            {
                await _next.Invoke(context);
                return;
            }
            var socket = await context.WebSockets.AcceptWebSocketAsync();
           
            await GetMarket(context, socket);
        }
       
        private async Task GetMarket(HttpContext context, WebSocket socket)
        {
            string userName = context.Request.Query["u"];
            Console.WriteLine("连接人：" + userName);

            _webSocketHandler.OnConnected(socket, userName);
            try
            {
                while (socket.State == WebSocketState.Open)
                {

                    await _webSocketHandler.ReceiveEntity<MessageEntity>(socket, async (result, messageEntity) =>
                    {
                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await _webSocketHandler.OnDisconnected(socket);
                            return;
                        }

                        var customSocket = _webSocketHandler.GetCustomWebSocket(userName);
                        if (customSocket == null)
                        {
                            return;
                        }
                        if (!customSocket.IsSubscribe)
                        {
                            _timer = new Timer(q =>
                            {
                                foreach (var stock in _stocks.Values)
                                {
                                    TryUpdateStockPrice(stock);

                                    _webSocketHandler.SendMessageAsync(socket, stock).ConfigureAwait(false);
                                }
                            }, null, _updateInterval, _updateInterval);

                            customSocket.IsSubscribe = true;
                            _webSocketHandler.UpdateCustomWebSocket(customSocket);
                        }
                    });
                }
                if (Enum.IsDefined(typeof(WebSocketCloseStatus), socket.CloseStatus))
                {
                    await _webSocketHandler.OnDisconnected(socket);
                }
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Close", default(CancellationToken));
                socket.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
        private bool TryUpdateStockPrice(Stock stock)
        {
            // Randomly choose whether to udpate this stock or not
            var r = _updateOrNotRandom.NextDouble();
            if (r > 0.1)
            {
                return false;
            }

            // Update the stock price by a random factor of the range percent
            var random = new Random((int)Math.Floor(stock.Price));
            var percentChange = random.NextDouble() * _rangePercent;
            var pos = random.NextDouble() > 0.51;
            var change = Math.Round(stock.Price * (decimal)percentChange, 2);
            change = pos ? change : -change;

            stock.Price += change;
            return true;
        }
        private bool UpdateStockPrices(Stock stock) {
            // Randomly choose whether to udpate this stock or not
            var r = _updateOrNotRandom.NextDouble();
            if (r > 0.1)
            {
                return false;
            }

            // Update the stock price by a random factor of the range percent
            var random = new Random((int)Math.Floor(stock.Price));
            var percentChange = random.NextDouble() * _rangePercent;
            var pos = random.NextDouble() > 0.51;
            var change = Math.Round(stock.Price * (decimal)percentChange, 2);
            change = pos ? change : -change;

            stock.Price += change;
            return true;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool IsWebSocket(HttpContext context)
        {
            return context.WebSockets.IsWebSocketRequest &&
                context.Request.Path == routePostfix;
        }
        private void LoadDefaultStocks()
        {
            _stocks.Clear();

            var stocks = new List<Stock>
            {
                new Stock { Symbol = "MSFT", Price = 107.56m },
                new Stock { Symbol = "AAPL", Price = 215.49m },
                new Stock { Symbol = "GOOG", Price = 1221.16m }
            };

            stocks.ForEach(stock => _stocks.TryAdd(stock.Symbol, stock));
        }

    }
}
