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
            //DuplexChannelFactory<IDuplexService> tcpFactory = new DuplexChannelFactory<IDuplexService>(
            //    new InstanceContext(new DuplexService()),
            //    new NetTcpBinding { Name = "netTcpBinding" },
            //    new EndpointAddress("net.tcp://localhost:3124/DuplexService")
            //);
            //IDuplexService tcpDuplexChannel = tcpFactory.CreateChannel();
            //tcpDuplexChannel.HelloWorld("TCP Duplex is running!");

            // Test DuplexChannelFactory using netHttpBinding
            DuplexChannelFactory<IDuplexService> webSocketFactory = new DuplexChannelFactory<IDuplexService>(
                new InstanceContext(new Callback()),
                new NetHttpBinding { Name = "textWSHttpBinding", MessageEncoding = NetHttpMessageEncoding.Text },
                new EndpointAddress("ws://localhost:3123/DuplexService")
            );
            IDuplexService webSocketDuplexChannel = webSocketFactory.CreateChannel();
            webSocketDuplexChannel.HelloWorld("Web Socket Duplex is running!");

            // Stop Client from exiting
            Console.ReadLine();
        }
    }
}
