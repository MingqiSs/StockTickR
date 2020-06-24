using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SuperSocketTest.Models
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_PackageHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] PktSize = new byte[2];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] MsgCount = new byte[1];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Filter = new byte[1];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SeqNum = new byte[4];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] SendTime = new byte[8];
    }
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_MsgType
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] MsgSize = new byte[2];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] MsgType = new byte[2];
    }
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Footer
    {
        /// <summary>
        /// Uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] ChannelID = new byte[2];
        /// <summary>
        /// 序号
        /// Uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SeqNum = new byte[4];
        /// <summary>
        /// 时间戳，纳秒=tick*10
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] SendTime = new byte[8];
    }
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_HeartBeatReq
    {
        public OMDC_PackageHeader head = new OMDC_PackageHeader();
        public OMDC_MsgType msgType = new OMDC_MsgType();
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] Filler = new byte[20];
    }
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class HeartBeatResp
    {

    }
    /// <summary>
    /// 10 40+14
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp10MarketDefinition:OMDC_MsgType
    {
        /// <summary>
        /// string 4
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] MarketCode = new byte[4];
        /// <summary>
        /// string 25
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
        public byte[] MarketName = new byte[25];
        /// <summary>
        /// string 3
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] CurrencyCode = new byte[3];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] NumberOfSecurities = new byte[4];
    }
    /// <summary>
    /// 11 464+8n+14
    /// n=NoUnderlyingSecurities
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp11SecurityDef : OMDC_MsgType
    {
        /// <summary>
        /// uint32 4
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// string 4
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] MarketCode = new byte[4];
        /// <summary>
        /// string 12
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] ISINCode = new byte[12];
        /// <summary>
        /// string 4
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] InstrumentType = new byte[4];
        /// <summary>
        /// uint8 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] ProductType = new byte[1];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Filler = new byte[1];
        /// <summary>
        /// string 2
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] SpreadTableCode = new byte[2];
        /// <summary>
        /// string 40
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] SecurityShortName = new byte[40];
        /// <summary>
        /// string 3
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] CurrencyCode = new byte[3];
        /// <summary>
        /// Binary 60
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[] SecurityNameGCCS = new byte[60];
        /// <summary>
        /// Binary60
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[] SecurityNameGB = new byte[60];
        /// <summary>
        /// uint32 4
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] LotSize = new byte[4];
        /// <summary>
        /// string 4
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Filler2 = new byte[4];
        /// <summary>
        /// int32 4
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] PreviousClosingPrice = new byte[4];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] VCMFlag = new byte[1];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] ShortSellFlag = new byte[1];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] CASFlag = new byte[1];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] CCASSFlag = new byte[1];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] DummySecurityFlag = new byte[1];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Filler3 = new byte[1];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] StampDutyFlag = new byte[1];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Filler4 = new byte[1];
        /// <summary>
        /// uint32 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] ListingDate = new byte[4];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] DelistingDate = new byte[4];
        /// <summary>
        /// string 38
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 38)]
        public byte[] FreeText = new byte[38];
        /// <summary>
        /// string 82
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 82)]
        public byte[] Filler5 = new byte[82];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] EFNFlag = new byte[1];
        /// <summary>
        /// uint32 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] AccruedInterest = new byte[4];
        /// <summary>
        /// uint32 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] CouponRate = new byte[4];
        /// <summary>
        /// string 42
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
        public byte[] Filler6 = new byte[42];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] ConversionRatio = new byte[4];
        /// <summary>
        /// int32 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] StrikePrice1 = new byte[4];
        /// <summary>
        /// int32 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] StrikePrice2 = new byte[4];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] MaturityDate = new byte[4];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] CallPutFlag = new byte[1];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Style = new byte[1];
        /// <summary>
        /// string 2
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Filler7 = new byte[2];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] WarrantType = new byte[1];
        /// <summary>
        /// int32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] CallPrice = new byte[4];
        /// <summary>
        /// uint8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] DecimalsInCallPrice = new byte[1];
        /// <summary>
        /// int32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Entitlement = new byte[4];
        /// <summary>
        /// uint8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] DecimalsInEntitlement = new byte[1];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] NoWarrantsPerEntitlement = new byte[4];
        /// <summary>
        /// string 33
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        public byte[] Filler8 = new byte[33];
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] NoUnderlyingSecurities = new byte[2];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] UnderlyingSecurityCode = new byte[4];
        /// <summary>
        /// string 4
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Filler9 = new byte[4];
    }
    /// <summary>
    /// 13
    /// 10+2n+14
    /// n=NoLiquidityProviders
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp13LiquidityProvider : OMDC_MsgType
    {
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] NoLiquidityProviders = new byte[2];
    }
    /// <summary>
    /// 13
    /// n=NoLiquidityProviders
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp13LiquidityProviderM
    {
        /// <summary>
        /// uint 16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] LPBrokerNumber = new byte[2];
    }
    /// <summary>
    /// 21
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp21
    {
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// uint8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] SuspensionIndicator = new byte[1];
        /// <summary>
        /// string 3
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Filler = new byte[3];
    }
    /// <summary>
    /// 22 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp22News
    {

    }
    /// <summary>
    /// 33
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp33 : OMDC_MsgType
    {
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// uint64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] OrderId = new byte[8];
        /// <summary>
        /// int32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Price = new byte[4];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Quantity = new byte[4];
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] BrokerID = new byte[2];
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Side = new byte[2];
    }
    /// <summary>
    /// 34
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp34 : OMDC_MsgType
    {
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// uint64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] OrderId = new byte[8];
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] BrokerID = new byte[2];
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Side = new byte[2];
    }
    /// <summary>
    /// 40 12+14
    /// TradeTicker
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_RespNominalPrice40 : OMDC_MsgType
    {
        /// <summary>
        /// uint32 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// int32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] NominalPrice = new byte[4];
    }
    /// <summary>
    /// 41 20+14
    /// TradeTicker
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_RespEquilibriumPrice41 : OMDC_MsgType
    {
        /// <summary>
        /// uint32 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// int32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Price = new byte[4];
        /// <summary>
        /// uint64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] AggregateQuantity = new byte[8];
    }
    /// <summary>
    /// 50 32+14
    /// TradeTicker
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_RespTrade50 : OMDC_MsgType
    {
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] TradeID = new byte[4];
        /// <summary>
        /// int32  3个暗示的小数位
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Price = new byte[4];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Quantity = new byte[4];
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] TrdType = new byte[2];
        /// <summary>
        /// string 2
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Filler = new byte[2];
        /// <summary>
        /// uint64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] TradeTime = new byte[8];
    }
    /// <summary>
    /// 52 36+14
    /// TradeTicker
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_RespTradeTicker52: OMDC_MsgType
    {
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] TickerID = new byte[4];
        /// <summary>
        /// int32  3个暗示的小数位
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Price = new byte[4];
        /// <summary>
        /// uint64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] AggregateQuantity = new byte[8];
        /// <summary>
        /// uint64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] TradeTime = new byte[8];
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] TrdType = new byte[2];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] TrdCancelFlag = new byte[1];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Filler = new byte[1];
    }

    /// <summary>
    /// 53header 12+24n
    /// n=NoEntries
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp53OrderBook : OMDC_MsgType
    {
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// string 3
        /// Filler可以考虑不用ascll解码，直接使用原值
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Filler = new byte[3];
        /// <summary>
        /// uint8 orderbook 实体数目
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] NoEntries = new byte[1];
    }
    /// <summary>
    /// 53Model
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp53OrderBookM
    {
        /// <summary>
        /// uint64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] AggregateQuantity = new byte[8];
        /// <summary>
        /// int32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Price = new byte[4];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] NumberOfOrders = new byte[4];
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Side = new byte[2];
        /// <summary>
        /// uint8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] PriceLevel = new byte[1];
        /// <summary>
        /// uint8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =1)]
        public byte[] UpdateAction = new byte[1];
        /// <summary>
        /// string 4
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Filler = new byte[4];
    }
    /// <summary>
    /// 54 
    /// 12 + 4n
    /// n=ItemCount
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp54BrokerQueue : OMDC_MsgType
    {
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// Uint8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] ItemCount = new byte[1];
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Side = new byte[2];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] BQMoreFlag = new byte[1];

    }
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp54M
    {
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Item = new byte[2];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Type = new byte[1];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Filler = new byte[1];
    }

    /// <summary>
    /// 60
    /// 52+14
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp60Statistics : OMDC_MsgType
    {
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] SecurityCode = new byte[4];
        /// <summary>
        /// uint64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] SharesTraded = new byte[8];
        /// <summary>
        /// int64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Turnover = new byte[8];
        /// <summary>
        /// int32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] HighPrice = new byte[4];
        /// <summary>
        /// int32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] LowPrice = new byte[4];
        /// <summary>
        /// int32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] LastPrice = new byte[4];
        /// <summary>
        /// int32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] VWAP = new byte[4];
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] ShortSellSharesTraded = new byte[4];
        /// <summary>
        /// int64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] ShortSellTurnover = new byte[8];
    }
    /// <summary>
    /// 61
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp61MarketTurnover : OMDC_MsgType
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] MarketCode = new byte[4];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] CurrencyCode = new byte[3];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Filler = new byte[1];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Turnover = new byte[8];
    }
    /// <summary>
    /// 70
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp70IndexDefinition
    {
        /// <summary>
        /// string 11
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        public byte[] IndexCode = new byte[11];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] IndexSource = new byte[1];
        /// <summary>
        /// string 3
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] CurrencyCode = new byte[3];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Filler = new byte[1];
    }
    /// <summary>
    /// 71
    /// 112
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp71IndexData
    {
        /// <summary>
        /// string 11
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        public byte[] IndexCode = new byte[11];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] IndexStatus = new byte[1];
        /// <summary>
        /// int64 8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] IndexTime = new byte[8];
        /// <summary>
        /// int64 8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] IndexValue = new byte[8];
        /// <summary>
        /// int64 8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] NetChgPrevDay = new byte[8];
        /// <summary>
        /// int64 8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] HighValue = new byte[8];
        /// <summary>
        /// int64 8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] LowValue = new byte[8];
        /// <summary>
        /// int64 8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] EASValue = new byte[8];
        /// <summary>
        /// int64 8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] IndexTurnover = new byte[8];
        /// <summary>
        /// int64 8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] OpeningValue = new byte[8];
        /// <summary>
        /// int64 8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] ClosingValue = new byte[8];
        /// <summary>
        /// int64 8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] PreviousSesClose = new byte[8];
        /// <summary>
        /// int64 8
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] IndexVolume = new byte[8];
        /// <summary>
        /// int32 4
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] NetChgPrevDayPct = new byte[4];
        /// <summary>
        /// string 1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] Exception = new byte[1];
        /// <summary>
        /// string 3
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Filler = new byte[3];

    }
    /// <summary>
    /// 80 24+14
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp80: OMDC_MsgType
    {
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] StockConnectMarket = new byte[2];
        /// <summary>
        /// string 2
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] TradingDirection = new byte[2];
        /// <summary>
        /// int64 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] DailyQuotaBalance = new byte[8];
        /// <summary>
        /// int64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] DailyQuotaBalanceTime = new byte[8];
    }
    /// <summary>
    /// 81
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp81 : OMDC_MsgType
    {
        /// <summary>
        /// uint16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] StockConnectMarket = new byte[2];
        /// <summary>
        /// string 2
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] TradingDirection = new byte[2];
        /// <summary>
        /// int64 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] BuyTurnover = new byte[8];
        /// <summary>
        /// int64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] SellTurnover = new byte[8];
        /// <summary>
        /// int64
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] BuyAndSellTurnover = new byte[8];
    }
    /// <summary>
    /// 203
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class OMDC_Resp203 : OMDC_MsgType
    {
        /// <summary>
        /// uint32
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] LastSeqNum = new byte[4];
    }
}
