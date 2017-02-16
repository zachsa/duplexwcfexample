using System.ServiceModel;

namespace DuplexWCF.Service
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract(IsOneWay = true)]
        void HelloWorld(string name);
    }
}
