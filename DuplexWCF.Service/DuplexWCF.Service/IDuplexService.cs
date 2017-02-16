using System.ServiceModel;

namespace DuplexWCF.Service
{
    [ServiceContract(CallbackContract = typeof(IDuplexService))]
    public interface IDuplexService
    {
        [OperationContract(IsOneWay = true)]
        void HelloWorld(string name);

        [OperationContract(IsOneWay = true)]
        void Callback(string msg);
    }
}