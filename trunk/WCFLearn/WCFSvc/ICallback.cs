using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFSvc
{
    using System.ServiceModel;

    public interface ICallback
    {
        // 回调操作也必须One Way  
        [OperationContract(IsOneWay = true)]
        void CallClient(int v);  
    }
}
