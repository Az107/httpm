using System;
using Httpm;

namespace prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Server server = new Server();
            server.Start();
            while(server.isAlive){
                System.Threading.Thread.Sleep(10000);
            }
            
        }
    }
}
