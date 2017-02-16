using System;
using System.ServiceModel;

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

            // Keep service alive
            Console.ReadLine();
        }
    }
}
