 using NUnit.Framework;
 using System.Net.Http;
 using Httpm;


namespace Httpm.test
{
    public class Tests
    {


        HttpClient httpClient ;
        Server server;
        
        [SetUp]
        public void Setup()
        {
            server = new Server();
        }

        [Test]
        public void Test1()
        {   
            
            try{
                server.Start();
                Assert.AreEqual(true,server.isAlive);
            }catch(System.Exception e){
                Assert.Fail(e.Message + ": " + e.Data + "\n" + e.HelpLink);

            }
        }


        [Test]
        public void Test2(){  
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync("http://localhost:8080/").Result;
            Assert.AreEqual("<HTML><BODY> Hello world!</BODY></HTML>",result);
        }
    }
}