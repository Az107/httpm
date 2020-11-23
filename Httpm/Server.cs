using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using MarkdownSharp;

namespace Httpm
{
    public class Server
    {
        public bool isAlive {get; private set;}
        public int Port {get; private set;}
        public HttpListener httpListener;
        private CancellationTokenSource ct = new CancellationTokenSource();
        //public IPAddress iP {get; private set;}
        //private IAsyncResult result;
        public String Header = "<link rel=\"stylesheet\" href=\"https://cdn.rawgit.com/Chalarangelo/mini.css/v3.0.1/dist/mini-default.min.css\">\n";


        public void Start(){

            httpListener.Start();
            isAlive = true;
            Task.Run(MainLoop,ct.Token);
            
            
        }


        private void MainLoop(){
            while(isAlive){
                IAsyncResult result =  httpListener.BeginGetContext(Response,httpListener);
                result.AsyncWaitHandle.WaitOne();
            }
        }

        private void Response(IAsyncResult ar){
            HttpListener listener = (HttpListener)ar.AsyncState;
            HttpListenerContext context = listener.EndGetContext(ar);
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            StreamHandler streamHandler = new StreamHandler(response.OutputStream);
            string responseString =  Header + File.ReadAllText("index.md");
            
            Markdown markdown = new Markdown();
            responseString = markdown.Transform(responseString);
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer,0,buffer.Length);
            output.Close();
        }
        
        public void Stop(){
            isAlive = false;
            ct.Cancel(false);
            httpListener.Stop();
            httpListener.Close();

        }

        public Server(int port){
            Init(port);
        }

        public Server(){
            Init(8080);
        }

        private void Init(int port){
            
            Port = port;
            httpListener = new HttpListener{ Prefixes = {$"http://localhost:{Port}/"}};
            

        }
        
    }
}