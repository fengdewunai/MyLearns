using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    using System.ServiceModel;
    using System.ServiceModel.Description;

    public class Program
    {
        static void Main(string[] args)
        {
            #region 通过配置文件启动服务

            ServiceHost host1 = new ServiceHost(typeof(HomeService));
            // 把自定义的IEndPointBehavior插入到终结点中  
            //foreach (var endpont in host1.Description.Endpoints)
            //{
            //    endpont.EndpointBehaviors.Add(new MyEndPointBehavior());
            //} 
            try
            {
                host1.Open();
                Console.WriteLine("HomeService服务启动");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                host1.Close();
            }

            ServiceHost host2 = new ServiceHost(typeof(SecondService));
            try
            {
                host2.Open();
                Console.WriteLine("SecondService服务启动");
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                host2.Close();
            }

            ServiceHost host3 = new ServiceHost(typeof(RestTest));
            try
            {
                host3.Open();
                Console.WriteLine("IRestTest服务启动");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                host3.Close();
            }

            Console.Read();
            #endregion

            //var host = new ServiceHost(typeof(HomeService), new Uri("net.tcp://127.0.0.1:19200/HomeService"));
            //host.AddServiceEndpoint(typeof(IHomeService), new NetTcpBinding(), new Uri("net.tcp://127.0.0.1:19200/HomeService"), new Uri("net.tcp://127.0.0.1:19300/HomeService"));
            ////公布元数据
            //host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = false });
            //host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

            //host.Open();
            //Console.WriteLine("服务已经开启。。。");
            //Console.Read();
        }
    }
}
