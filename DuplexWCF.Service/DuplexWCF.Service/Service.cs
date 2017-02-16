using System;
using System.ServiceModel;

namespace DuplexWCF.Service
{
    public class Service : IService
    {
        public void HelloWorld(string name)
        {
            Console.WriteLine("Hello " + name);
        }
    }
}
