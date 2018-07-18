using System.ServiceModel;

namespace DuplexWCF.Service
{
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IDuplexService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void HelloWorld(string name);
    }
}