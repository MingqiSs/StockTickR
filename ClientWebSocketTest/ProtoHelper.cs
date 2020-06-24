using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWebSocketTest
{
    public class ProtoHelper
    {
        public static byte[] Serialize<T>(T t)
        {
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream,t);
                return stream.ToArray();
            }
        }

        public static T Deserialize<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            using (var stream = new MemoryStream(data))
            {
                return Serializer.Deserialize<T>(stream);
            }
        }
    }
}
