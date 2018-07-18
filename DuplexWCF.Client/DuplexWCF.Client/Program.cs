using System;
using System.ServiceModel;
using DuplexWCF.Service;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client Started");

            // Test DuplexChannelFactory using netTcpBinding
            DuplexChannelFactory<IDuplexService> factory = new DuplexChannelFactory<IDuplexService>(
                new InstanceContext(new DuplexService()),
                new NetTcpBinding { Name = "netTcpBinding" },
                new EndpointAddress("net.tcp://localhost:3124/DuplexService")
            );
            IDuplexService duplexChannel = factory.CreateChannel();
            duplexChannel.HelloWorld("Duplex is running!");

            // Test DuplexChannelFactory using netHttpBinding


            // Stop Client from exiting
            Console.ReadLine();
        }
    }
}
