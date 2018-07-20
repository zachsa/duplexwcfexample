using System;
using System.Net.WebSockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using DuplexWCF.Service;

namespace Client
{
    class Program
    {
        private static Message CreateMessage(string txt)
        {
            Message msg = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, "*", Encoding.UTF8.GetBytes(txt));
            return msg;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Client Started");

            // Test DuplexChannelFactory using netHttpBinding
            DuplexChannelFactory<IDuplexService> webSocketFactory = new DuplexChannelFactory<IDuplexService>(
                new InstanceContext(new Callback()),
                new NetHttpBinding { Name = "netHttpBindingDuplexService", MessageEncoding = NetHttpMessageEncoding.Text},
                new EndpointAddress("ws://localhost:3123/DuplexService")
            );
            IDuplexService webSocketDuplexChannel = webSocketFactory.CreateChannel();
            
            webSocketDuplexChannel.HelloWorld(CreateMessage("Web Socket Duplex is running!"));

            // Stop Client from exiting
            Console.ReadLine();
        }
    }
}
