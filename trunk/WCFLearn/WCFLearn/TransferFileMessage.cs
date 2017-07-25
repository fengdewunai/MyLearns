using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    using System.IO;
    using System.ServiceModel;

    [MessageContract]  
    public class TransferFileMessage
    {
        [MessageHeader]
        public string FileName; 

        [MessageBodyMember]
        public Stream FileStream;   
    }
}
