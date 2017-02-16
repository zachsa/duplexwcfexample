
using System.Runtime.Serialization;

namespace DuplexWCF.Service.Object
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public string itemName { get; set; }
    }
}
