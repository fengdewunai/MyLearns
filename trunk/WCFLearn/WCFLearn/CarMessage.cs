using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    using System.ServiceModel;

    [MessageContract]
    public class CarMessage
    {
        [MessageBodyMember]
        public DateTest Data;
        [MessageBodyMember]
        public int MakeYear;
        [MessageHeader]
        public string IP;
    }  
}
