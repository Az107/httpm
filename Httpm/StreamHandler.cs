using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;

namespace Httpm
{
    public class StreamHandler{

        private Stream stream;


        public StreamHandler(Stream stream){
            stream = stream;
        }
        public void Send(String data){
            byte[] byteArray = Encoding.ASCII.GetBytes(data);
            stream.Write(byteArray,0,byteArray.Length);
        }   
        

        public String Recv(){
            String result = String.Empty;
            byte[] byteArray = new byte[1024];
            stream.Read(byteArray,0,1024);
            return result;
        } 

        
    }
}