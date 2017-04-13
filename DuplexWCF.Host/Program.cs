using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;

namespace DuplexWCF.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the normal channel factory
            ServiceHost host = new ServiceHost(typeof(Service.Service));
            host.Open();
            Console.WriteLine("Unidirectional service started");

            // Create the duplex channel factory
            ServiceHost duplexHost = new ServiceHost(typeof(Service.DuplexService));
            duplexHost.Open();
            Console.WriteLine("Duplex service started");

            WebServiceHost webHost = new WebServiceHost(typeof(Service.WebService));
            webHost.Open();
            Console.WriteLine("Web host started");

            // Keep service alive
            Console.ReadLine();
        }
    }
}
