
using System.Runtime.Serialization;

namespace WCFLearn
{
    [DataContract(Namespace = "http://tempuri.org/", Name = "Update")]
    public class DateTest
    {
        [DataMember]
        public int StrLength { get; set; }
    }
}
