using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplexWCF.Service
{
    public class Callback : ICallback
    {
        public void SendMessageToClient(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}