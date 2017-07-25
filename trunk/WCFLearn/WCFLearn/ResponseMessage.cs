using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    using System.ServiceModel;

    [MessageContract]
    public class ResponseMessage
    {
        [MessageBodyMember]
        public int a;
        [MessageBodyMember]
        public int b;
        [MessageBodyMember]
        public int c;


    }
}
