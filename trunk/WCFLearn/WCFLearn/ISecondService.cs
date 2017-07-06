using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    using System.ServiceModel;

    [ServiceContract]
    interface ISecondService
    {
        [OperationContract]
        int GetStrLength(string str);
    }
}
