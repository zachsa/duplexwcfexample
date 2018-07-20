using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace DuplexWCF.Service
{
    public class Callback : ICallback
    {
        public void BroadcastToNetClient(Message msg)
        {
            string txt = Encoding.UTF8.GetString(msg.GetBody<byte[]>());
            Console.WriteLine(txt);
        }

        public void BroadcastToBrowserClient(Message msg)
        {
            Console.WriteLine("This is the callback");
        }
    }
}