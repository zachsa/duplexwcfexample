using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace DuplexWCF.Service
{
    [ServiceContract]
    public interface ICallback
    {
        //[OperationContract(IsOneWay = true)]
        //void SendMessageToClient(string msg);

        [OperationContract(IsOneWay = true, Action = "*")]
        void SendMessageToClient(Message msg);
    }
}