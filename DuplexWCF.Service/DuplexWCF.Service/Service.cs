﻿using System;
using System.IO;
using System.ServiceModel;
using System.Text;

namespace DuplexWCF.Service
{
    public class Service : IService
    {
        public void HelloWorld(string name)
        {
            Console.WriteLine("Hello " + name);
        }

        
        public string getHTMLpage()
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
                return page;
            }
        }
    }
}
