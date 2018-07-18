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

            // Test DuplexChannelFactory
            NetTcpBinding duplexBinding = new NetTcpBinding
            {
                Name = "netTcpBinding"
            };
            EndpointAddress duplexAddress = new EndpointAddress("net.tcp://localhost:3124/DuplexService");
            DuplexService serviceWithCallbackContract = new DuplexService();
            InstanceContext instanceContext = new InstanceContext(serviceWithCallbackContract);
            DuplexChannelFactory<IDuplexService> factory = new DuplexChannelFactory<IDuplexService>(instanceContext, duplexBinding, duplexAddress);
            IDuplexService duplexChannel = factory.CreateChannel();
            duplexChannel.HelloWorld("Duplex is running!");

            // Stop Client from exiting
            Console.ReadLine();
        }
    }
}
