using System;
using System.ServiceModel;

namespace DuplexWCF.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DuplexService : IDuplexService
    {
        public void HelloWorld(string name)
        {
            Console.WriteLine("Hello " + name + ", now I will call the callback");

            // Call the callback
            IDuplexService callback = OperationContext.Current.GetCallbackChannel<IDuplexService>();
            callback.Callback("I am the callback!");
        }

        public void Callback(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}