using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace DuplexWCF.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DuplexService : IDuplexService
    {
        //public void HelloWorld(string name)
        //{
        //    Console.WriteLine("Hello " + name + ", now I will call the callback");

        //    // Call the callback
        //    ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
        //    callback.SendMessageToClient("I am the callback!");
            
        //}

        public void HelloWorld(Message name)
        {
            Console.WriteLine("Hello this is from a web client");

            // Call the callback
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            //callback.SendMessageToClient(null);

        }
    }
}