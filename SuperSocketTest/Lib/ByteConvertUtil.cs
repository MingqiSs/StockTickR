using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSocketTest.Lib
{
    /// <summary>
    /// 
    /// </summary>
    public static class ByteConvertUtil
    {
        #region 字符串和Byte之间的转化
        /// <summary>
        /// 数字和字节之间互转
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int ToBitConverter(this int num)
        {
            int temp = 0;
            byte[] bytes = BitConverter.GetBytes(num);//将int32转换为字节数组
            temp = BitConverter.ToInt32(bytes, 0);//将字节数组内容再转成int32类型
            return temp;
        }

        /// <summary>
        /// 数字和字节之间互转
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ToBitConverterSocket(this int num)
        {
            return BitConverter.GetBytes(num).ToHexString();
        }

        /// <summary>
        /// 将字符串转为16进制字符，允许中文
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string ToHexString(this string s, Encoding encode, string spanString = "")
        {
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result16 = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符
            {
                result16 += Convert.ToString(b[i], 16) + spanString;
            }
            return $"{result16}";
        }

        /// <summary>
        /// 将字符串转为16进制字符，允许中文
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string ToSocketHexString(this string s, Encoding encode, string spanString = "")
        {
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result16 = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符
            {
                result16 += Convert.ToString(b[i], 16) + spanString;
            }
            return $"{s.Length.ToBitConverterSocket()}{result16}";
        }

        /// <summary>
        /// 将16进制字符串转为字符串
        /// </summary>
        /// <param name="hs"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string ToNString(this string hs, Encoding encode)
        {
            string strTemp = "";
            byte[] b = new byte[hs.Length / 2];
            for (int i = 0; i < hs.Length / 2; i++)
            {
                strTemp = hs.Substring(i * 2, 2);
                b[i] = Convert.ToByte(strTemp, 16);
            }
            //按照指定编码将字节数组变为字符串
            return encode.GetString(b);
        }

        /// <summary>
        /// 将16进制字符串转为字符串
        /// </summary>
        /// <param name="hs"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string ToSocketNString(this string hs, Encoding encode)
        {
            string strTemp = "";
            byte[] b = new byte[hs.Length / 2];
            for (int i = 0; i < hs.Length / 2; i++)
            {
                strTemp = hs.Substring(i * 2, 2);
                b[i] = Convert.ToByte(strTemp, 16);
            }
            // 按照指定编码将字节数组变为字符串
            return encode.GetString(b);
        }

        /// <summary>
        /// byte[]转为16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 将16进制的字符串转为byte[]
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] ToHexByte(this string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0) hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);

                if (returnBytes[i] == 0xc2)
                {
                    int test;
                    test = 1;
                }
            }
            return returnBytes;
        }

        /// <summary>
        /// 将字符串转为转为16进制的byte[]
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] ToSocketHexByte(this string s)
        {
            return s.ToSocketHexString(Encoding.UTF8).ToHexByte();
        }

        #endregion

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
    }
}
