using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Net.WebSockets;

namespace DuplexWCF.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
    public class DuplexService : IDuplexService
    {

        private Message CreateByteArrayMessage(string txt)
        {
            Message msg = ByteStreamMessage.CreateMessage(new ArraySegment<byte>(Encoding.UTF8.GetBytes(txt)));
            msg.Properties["WebSocketMessageProperty"] = new WebSocketMessageProperty { MessageType = WebSocketMessageType.Text };
            return msg;
        }

        private Message CreateSoapMessage(string txt)
        {
            Message msg = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, "BroadcastToNetClient", Encoding.UTF8.GetBytes(txt));
            msg.Properties["WebSocketMessageProperty"] = new WebSocketMessageProperty { MessageType = WebSocketMessageType.Text };
            return msg;
        }

        public void HelloWorld(Message msg)
        {
            // Get context
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            if (msg.IsEmpty || ((IChannel)callback).State != CommunicationState.Opened) return;
            string txt = Encoding.UTF8.GetString(msg.GetBody<byte[]>());

            // Callback client
            try
            {
                callback.BroadcastToNetClient(CreateSoapMessage($"Hello {txt}"));
            }
            catch
            {
                callback.BroadcastToBrowserClient(CreateByteArrayMessage($"Hello {txt}"));
            }            
        }
    }
}