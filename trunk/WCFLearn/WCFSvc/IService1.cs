using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFSvc
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ICallback))]
    public interface IService1
    {
        [OperationContract(IsOneWay = true,IsInitiating = false)]
        void SetData(string value);

        [OperationContract]
        string GetData();

        [OperationContract(IsInitiating = true)]
        void StartSession();

        [OperationContract(IsOneWay = true, /* 使用回调，必须为OneWay */
            IsTerminating = true, /* 该操作标识会话终止 */
            IsInitiating = false)]
        void EndSession();

        // 会话从调用该操作启动  
        [OperationContract(IsOneWay = true, /* 必须 */
            IsInitiating = true, /* 启动会话 */
            IsTerminating = false)]
        void CallServerOp();  

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }


    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
