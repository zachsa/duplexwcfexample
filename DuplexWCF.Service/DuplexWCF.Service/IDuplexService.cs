using System.ServiceModel;
using System.ServiceModel.Channels;

namespace DuplexWCF.Service
{
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IDuplexService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void HelloWorld(Message msg);
    }
}