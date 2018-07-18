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
        //public void SendMessageToClient(string msg)
        //{
        //    Console.WriteLine(msg);
        //}

        public void SendMessageToClient2(Message msg)
        {
            Console.WriteLine("hi");
        }
    }
}