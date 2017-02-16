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

            // Test ChannelFactory
            NetTcpBinding binding = new NetTcpBinding();
            binding.Name = "netTcpBindingBasic"; // Note this is actually the name of a binding, not a service as defined in the host app.config
            EndpointAddress address = new EndpointAddress("net.tcp://localhost:3123/Service");
            IService channel = new ChannelFactory<IService>(binding, address).CreateChannel();
            channel.HelloWorld("ChannelFactory");

            // Test DuplexChannelFactory
            NetTcpBinding duplexBinding = new NetTcpBinding();
            duplexBinding.Name = "netTcpBindingBasic"; // Note this is actually the name of a binding, not a service as defined in the host app.config
            EndpointAddress duplexAddress = new EndpointAddress("net.tcp://localhost:3123/DuplexService");
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
