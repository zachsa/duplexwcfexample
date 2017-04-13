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
                return new MemoryStream(result);
            }
        }

        public string JsTest()
        {
            return "I came to the page later";
        }
    }
}
