using SuperSocket.ClientEngine;
using SuperSocketTest.Lib;
using SuperSocketTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperSocketTest
{
  public  class USMarketClient
    {
        private AsyncTcpSession m_wsQClient = null;
        private IPEndPoint ipp = null;
        public void Init(string ip, int port)
        {
            ipp = new System.Net.IPEndPoint(System.Net.IPAddress.Parse(ip), port);
            m_wsQClient = WSClient_ReConnect();
        }
        private AsyncTcpSession WSClient_ReConnect()
        {
            var wsClient = new AsyncTcpSession();
            wsClient.Connected += new EventHandler(WSClient__Opened);
            wsClient.Closed += new EventHandler(WSClient__Closed);
            wsClient.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(WSClient__Error);
            wsClient.DataReceived += new EventHandler<SuperSocket.ClientEngine.DataEventArgs>(WSClient_DataReceived);
            wsClient.ReceiveBufferSize = 1024 * 64;
            wsClient.Connect(ipp);
            return wsClient;
        }
        int num = 0;
        public long GETTick()
        {
            long Utc_1970_now_Ticks = System.DateTime.UtcNow.ToUniversalTime().Ticks - 621355968000000000;
            return Utc_1970_now_Ticks;
        }
        private void WSClient__Opened(object sender, EventArgs e)
        {
            if (m_wsQClient.IsConnected && ((AsyncTcpSession)sender).LocalEndPoint == m_wsQClient?.LocalEndPoint)
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        if (m_wsQClient != null && m_wsQClient.IsConnected)
                        {
                            OMDC_HeartBeatReq HB = new OMDC_HeartBeatReq();
                            HB.head.PktSize = BitConverter.GetBytes((UInt16)40);
                            HB.head.MsgCount[0] = 1;
                            HB.head.Filter[0] = 0;
                            HB.head.SeqNum = BitConverter.GetBytes(num);
                            HB.head.SendTime = BitConverter.GetBytes(GETTick() * 100);
                            HB.msgType.MsgSize = BitConverter.GetBytes((UInt16)24);
                            HB.msgType.MsgType = BitConverter.GetBytes((UInt16)1000);
                            byte[] request = SerHelper.Serialize(HB);

                            m_wsQClient.Send(request);
                            Console.WriteLine($"heartbeat_{num}:{ByteConvertUtil.byteToHexStr(request)}");
                        }
                        num++;
                        Thread.Sleep(1500);
                    }

                });

            }
        }
        private void WSClient__Closed(object sender, EventArgs e)
        {
            try
            {
                if (!((AsyncTcpSession)sender).IsConnected)
                {
                    Thread.Sleep(2000);
                    WSClient_ReConnect();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[wsClient_Closed]: {ipp.Address} {ipp.Port} {ex.ToString()}");
            }
        }
        private void WSClient__Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            var sss = (AsyncTcpSession)sender;
            Console.WriteLine($"[wsClient_Error]:{ipp.Address} {ipp.Port}  error!");
        }
        /// <summary>
        /// 接收返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WSClient_DataReceived(object sender, DataEventArgs e)
        {
            byte[] receiveBuffer = e.Data.Take(e.Length).ToArray();
            string resp = ByteConvertUtil.byteToHexStr(receiveBuffer);
            Console.WriteLine(resp);
        }
    }
}
