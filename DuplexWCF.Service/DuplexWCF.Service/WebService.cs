using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DuplexWCF.Service
{
    public class WebService : IWebService
    {
        public System.IO.Stream Home()
        {
            Console.WriteLine("Page requested");

            // Open the stream and read it back.
            using (FileStream fs = File.Open(@"index.html", FileMode.Open))
            {
                string page = "";
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    page += temp.GetString(b);
                }
                byte[] result = Encoding.UTF8.GetBytes(page);
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
                //WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "127.0.0.1");
                return new MemoryStream(result);
            }
        }

        public System.IO.Stream JsTest()
        {
            using (FileStream fs = File.Open(@"index.html", FileMode.Open))
            {
                string page = "Hello again!";
                byte[] result = Encoding.UTF8.GetBytes(page);
                WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Credentials", "true");
                //WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "https://db.twirp.me");
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "http://avestascorecard.com");
                return new MemoryStream(result);
            }
        }
    }
}
