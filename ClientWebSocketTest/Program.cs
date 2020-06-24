using ProtoBuf;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
namespace ClientWebSocketTest
{
    class Program
    {


        static async Task Main(string[] args)
        {
            await WebSocketDemo3().ConfigureAwait(false);

        }
        public static async Task WebSocketDemo()
        {
            ClientWebSocket _webSocket = new ClientWebSocket();
            CancellationToken _cancellation = new CancellationToken();

            //建立连接
            var url = "ws://192.168.1.46:7010/quote?u=18001";
            await _webSocket.ConnectAsync(new Uri(url), _cancellation).ConfigureAwait(false);

            var rq = new
            {
                message = "",
                sendTime = "sendTime",
                receiver = "system",
                sender = "18001",
                type = 3
            };

            var bsend = ProtoHelper.Serialize(rq);

            await _webSocket.SendAsync(new ArraySegment<byte>(bsend), WebSocketMessageType.Binary, true, _cancellation).ConfigureAwait(false); //发送数据

            while (_webSocket.State == WebSocketState.Open)
            {
                var buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result;
                do
                {
                    result = await _webSocket.ReceiveAsync(buffer, _cancellation);//接收数据
                }
                while (!result.EndOfMessage);
                var data = buffer.Skip(0).Take(result.Count).ToArray();
                var p = ProtoHelper.Deserialize<MessageEntity>(data);
                var str = Newtonsoft.Json.JsonConvert.SerializeObject(p);
                Console.WriteLine(str);
            }
        }
        public static async Task WebSocketDemo1()
        {
            ClientWebSocket _webSocket = new ClientWebSocket();
            CancellationToken _cancellation = new CancellationToken();

            //建立连接
            var url = "wss://localhost:44373/stocks?u=18001";
            await _webSocket.ConnectAsync(new Uri(url), _cancellation).ConfigureAwait(false);

            var rq = new
            {
                message = "",
                sendTime = DateTime.Now,
                receiver = "system",
                sender = "18001",
                type = 1
            };

            var str = Newtonsoft.Json.JsonConvert.SerializeObject(rq);
            var bsend = Encoding.UTF8.GetBytes(str);
            await _webSocket.SendAsync(new ArraySegment<byte>(bsend), WebSocketMessageType.Text, true, _cancellation).ConfigureAwait(false); //发送数据

            while (_webSocket.State == WebSocketState.Open)
            {
                var buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result;
                do
                {
                    result = await _webSocket.ReceiveAsync(buffer, _cancellation);//接收数据
                }
                while (!result.EndOfMessage);
                 buffer = buffer.Skip(0).Take(result.Count).ToArray();
                var data = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                Console.WriteLine(data);
            }
        }
      

        public static async Task WebSocketDemo2()
        {
            ClientWebSocket _webSocket = new ClientWebSocket();
            CancellationToken _cancellation = new CancellationToken();

            //建立连接
            var url = "wss://tradeapijf12.mc-forex.net:4433/quote";
           
            await _webSocket.ConnectAsync(new Uri(url), _cancellation).ConfigureAwait(false);

            var rq = new 
            {
                i = 0,
                t = 7,
                d = new 
                {
                    d = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36",
                    o = "Windows",
                    k = 4,
                    v = "9.9.9",
                    u = Guid.NewGuid().ToString("N"),

                }
            };

            var str = Newtonsoft.Json.JsonConvert.SerializeObject(rq);
            var bsend = Encoding.UTF8.GetBytes(str);

            await _webSocket.SendAsync(new ArraySegment<byte>(bsend), WebSocketMessageType.Text, true, _cancellation).ConfigureAwait(false); //发送数据

            while (_webSocket.State == WebSocketState.Open)
            {

                var buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result;
                do
                {
                    result = await _webSocket.ReceiveAsync(buffer, _cancellation);//接收数据
                }
                while (!result.EndOfMessage);

                var data = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);

                #region test
                // using (var ms = new MemoryStream())
                // {
                //     WebSocketReceiveResult result;
                //     do
                //     {
                //         result = await _webSocket.ReceiveAsync(buffer, CancellationToken.None);//接收数据

                //         var json = Encoding.UTF8.GetString(buffer.Array);

                //         ms.Write(buffer.Array, buffer.Offset, result.Count);
                //     }
                //     while (!result.EndOfMessage);

                //     ms.Seek(0, SeekOrigin.Begin);

                //     using (var reader = new StreamReader(ms, Encoding.UTF8))
                //     {
                //         string data = await reader.ReadToEndAsync().ConfigureAwait(false);
                //         Console.WriteLine(data);
                //     }
                // }
                #endregion

                Console.WriteLine(data);
            }
        }

        public static async Task WebSocketDemo3()
        {
            //建立连接
            var url = "wss://192.168.1.46:141";
            ClientWebSocket _webSocket = new ClientWebSocket();
            CancellationToken _cancellation = new CancellationToken();

            await _webSocket.ConnectAsync(new Uri(url), _cancellation).ConfigureAwait(false);

            var rq = new
            {
                message = "",
                sendTime = "sendTime",
                receiver = "system",
                sender = "18001",
                type = 3
            };

            var bsend = ProtoHelper.Serialize(rq);

            await _webSocket.SendAsync(new ArraySegment<byte>(bsend), WebSocketMessageType.Binary, true, _cancellation).ConfigureAwait(false); //发送数据

            while (_webSocket.State == WebSocketState.Open)
            {
                var buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result;
                do
                {
                    result = await _webSocket.ReceiveAsync(buffer, _cancellation);//接收数据
                }
                while (!result.EndOfMessage);
                var data = buffer.Skip(0).Take(result.Count).ToArray();
                var p = ProtoHelper.Deserialize<MessageEntity>(data);
                var str = Newtonsoft.Json.JsonConvert.SerializeObject(p);
                Console.WriteLine(str);
            }
        }
    }
   

    [ProtoContract]
    public class MessageEntity
    {
        /// <summary>
        /// 消息发送者
        /// </summary>
        /// <value></value>
        [ProtoMember(1)]
        public string Sender { get; set; }

        /// <summary>
        /// 消息接收者
        /// </summary>
        /// <value></value>
        [ProtoMember(2)]
        public string Receiver { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        /// <value></value>
        [ProtoMember(3)]
        public string SendTime { get; set; }// = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 消息内容
        /// </summary>
        /// <value></value>
        [ProtoMember(4)]
        public string Message { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        /// <value></value>
        //[JsonConverter(typeof(StringEnumConverter))]
        [ProtoMember(5)]
        public int Type { get; set; }
    }

    public enum MessageType
    {
        /// <summary>
        /// 连接
        /// </summary>
        Connection = 1,
        /// <summary>
        /// 心跳
        /// </summary>
        KeepLive,
        /// <summary>
        /// 行情
        /// </summary>
        Quote,
        /// <summary>
        /// 登录
        /// </summary>
        Login,
        /// <summary>
        /// 下单
        /// </summary>
        OpenOrder,
        /// <summary>
        /// 平仓
        /// </summary>
        CloseOrder,
        /// <summary>
        /// 认证失败
        /// </summary>
        AuthFailed,
        /// <summary>
        /// 下单/平仓失败
        /// </summary>
        OrderFailed,

        /// <summary>
        /// 
        /// </summary>
        Closed,
        /// <summary>
        /// 
        /// </summary>
    }
}
