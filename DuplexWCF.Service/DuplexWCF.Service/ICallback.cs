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
        [OperationContract(IsOneWay = true, Action = "BroadcastToNetClient")]
        void BroadcastToNetClient(Message msg);

        [OperationContract(IsOneWay = true, Action = "*")]
        void BroadcastToBrowserClient(Message msg);
    }
}