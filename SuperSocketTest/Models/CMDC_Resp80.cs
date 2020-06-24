using SuperSocketTest.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSocketTest.Models
{
    public class CMDC_Resp80: BaseDisposable
    {
        private bool _disposed; //表示是否已经被回收
        public CMDC_Resp80(byte[] buf)
        {
            Buffer.BlockCopy(buf, 0, MsgSize, 0, 2);
            Buffer.BlockCopy(buf, 2, MsgType, 0, 2);
            Buffer.BlockCopy(buf, 4, StockConnectMarket, 0, 2);
            Buffer.BlockCopy(buf, 6, TradingDirection, 0, 2);
            Buffer.BlockCopy(buf, 8, DailyQuotaBalance, 0, 8);
            Buffer.BlockCopy(buf, 16, DailyQuotaBalanceTime, 0, 8);
        }
        protected override void Dispose(bool disposing)
        {
            if (!_disposed) //如果还没有被回收
            {
                if (disposing) //如果需要回收一些托管资源
                {
                    //TODO:回收托管资源，调用IDisposable的Dispose()方法就可以

                }
                //TODO：回收非托管资源，把之设置为null，等待CLR调用析构函数的时候回收
                MsgSize = null;
                MsgType = null;
                StockConnectMarket = null;
                TradingDirection = null;
                DailyQuotaBalance = null;
                DailyQuotaBalanceTime = null;

                _disposed = true;

            }
            base.Dispose(disposing);//再调用父类的垃圾回收逻辑
        }

        public byte[] MsgSize = new byte[2];

        public byte[] MsgType = new byte[2];

        public byte[] StockConnectMarket = new byte[2];

        public byte[] TradingDirection = new byte[2];

        public byte[] DailyQuotaBalance = new byte[8];//数据体

        public byte[] DailyQuotaBalanceTime = new byte[8];
    }
}
