using System;
using System.IO;
using System.ServiceModel;
using System.Text;

namespace DuplexWCF.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the duplex channel factory
            ServiceHost duplexHost = new ServiceHost(typeof(Service.DuplexService));
            duplexHost.Open();
            Console.WriteLine("Duplex service started");

            // Keep service alive
            Console.ReadLine();
        }
    }
}
