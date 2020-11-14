using System;
using System.Net.Http;
using System.Net.Sockets;

namespace Httpm
{
    public class Client{

        public int port {get;private set;}
        private TcpClient tcpClient;
        
        

        public Client(int port){
            port = port;
            



        }

    }
}