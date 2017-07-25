using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFSvc
{
    using System.IO;
    using System.Web;

    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IService1
    {
        private string _data = "未赋值";

        public void SetData(string value)
        {
            try
            {
                WriteFile(string.Format("Service1收到SetData请求，对象实例为{0}", this.GetHashCode()));
                this._data = value;
            }
            catch (Exception ex)
            {
                
            }
            
        }

        [OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.AfterCall)]
        public string GetData()
        {
            try
            {
                WriteFile(string.Format("Service1收到GetData请求，对象实例为{0}", this.GetHashCode()));
                return this._data;
            }
            catch (Exception ex)
            {
                var aa = ex.Message;
                return ex.Message;
            }
            
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public void EndSession()
        {
            WriteFile(string.Format("Service1收到EndSession请求，会话结束"));
        }

        public void WriteFile(string msg)
        {
            FileStream fileStream = new FileStream("C:\\aaaa.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fileStream);
            sw.WriteLine(msg);
            sw.Close();
            fileStream.Close();
        }


        public void StartSession()
        {
            WriteFile(string.Format("Service1收到StartSession请求，新会话开始"));
        }
    }
}
