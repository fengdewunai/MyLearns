
using System.Runtime.Serialization;

namespace WCFLearn
{
    [DataContract(Namespace = "http://tempuri.org/")]
    public class DateTest
    {
        [DataMember]
        public int StrLength { get; set; }
    }
}
