using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace StockTickekTest.Hubs
{
    public class StockTickerHub : Hub
    {
        private readonly StockTicker _stockTicker;

        public StockTickerHub(StockTicker stockTicker)
        {
            _stockTicker = stockTicker;
        }
        private readonly ConcurrentDictionary<string, Stock> _stocks = new ConcurrentDictionary<string, Stock>();
        public IEnumerable<Stock> GetAllStocks()
        {
             return _stockTicker.GetAllStocks();          
        }
        public ChannelReader<Stock> StreamStocks()
        {
            var list = _stockTicker.StreamStocks().AsChannelReader(10); 
            return list;
        }

        public string GetMarketState()
        {
            return _stockTicker.MarketState.ToString();
        }

        public async Task OpenMarket()
        {
            await _stockTicker.OpenMarket();
        }

        public async Task CloseMarket()
        {
            await _stockTicker.CloseMarket();
        }

        public async Task Reset()
        {
            await _stockTicker.Reset();
        }
    }
}
