using System;

namespace SuperSocketTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //连接HKStock行情服务 订阅，计算
            USMarketClient client = new USMarketClient();
            //client.Init("192.168.1.70", 11);
            client.Init("152.101.24.218", 6900);
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("=> ");
                Console.ForegroundColor = ConsoleColor.White;
                string cmd = Console.ReadLine();
                string[] parms = cmd.Split('.', StringSplitOptions.RemoveEmptyEntries);
                switch (parms[0])
                {
                    case "exit":
                        //todo 推出程序
                        break;
                }
            }
       
        }
    }
}
