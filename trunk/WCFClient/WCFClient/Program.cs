using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    using System.IO;
    using System.Net;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Threading;
    using System.Web.Script.Serialization;

    using WCFClient.HomeService;
    using WCFClient.SecondService;
    using WCFClient.TCPService;

    class Program
    {
        static void Main(string[] args)
        {
            var homeService = new HomeServiceClient();
            homeService.GetDataContract(new DateTest(){ StrLength=34});
          
            Console.WriteLine(homeService.GetLength("gaofeng"));

            var secondService = new SecondServiceClient();
            using (OperationContextScope scope = new OperationContextScope(secondService.InnerChannel))
            {
                MessageHeader myHeader = MessageHeader.CreateHeader(
                    "header", "http://my", "你好，这是消息头。");
                OperationContext.Current.OutgoingMessageHeaders.Add(myHeader);

                // 调用方法  
                Console.WriteLine(secondService.GetStrLength("jiajia"));
                Console.WriteLine("服务方法已调用。");
            }  
            
            TestChannel();
            TestRestAdd();
            TestMessageContract(homeService);
            TestUploadFile(homeService);
            TestUploadFileWithMessageContract(homeService);
            TestTCPService();
            Console.Read();
        }

        /// <summary>
        /// 通过channel与服务端通信
        /// </summary>
        static public void TestChannel()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            CustomBinding cb = new CustomBinding();
            BindingParameterCollection param = new BindingParameterCollection();
            BindingContext bc = new BindingContext(cb, param);
            Message request = Message.CreateMessage(MessageVersion.Soap11, "http://tempuri.org/IHomeService/TestMessage", "gaofeng");
            request.Headers.Add(MessageHeader.CreateHeader("ip", string.Empty, Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString()));
            IChannelFactory<IRequestChannel> factory = binding.BuildChannelFactory<IRequestChannel>(param);
            factory.Open();
            IRequestChannel channel = factory.CreateChannel(new EndpointAddress("http://127.0.0.1:28200/HomeService"));
            channel.Open();
            var res = channel.Request(request);
            Console.WriteLine("结果为：" + res.GetBody<int>());
            channel.Close();
            factory.Close();
        }

        public static void TestRestAdd()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("http://127.0.0.1:49200/RestTest/Add");
            Encoding encoding = Encoding.UTF8;

            string para = new JavaScriptSerializer().Serialize(new { name = "李四", age = 11 });
            byte[] bs = Encoding.UTF8.GetBytes(para);

            string responseData = String.Empty;
            req.Method = "POST";
            req.ContentType = "application/json";
            req.ContentLength = bs.Length;
            using (Stream stream = req.GetRequestStream())
            {
                stream.Write(bs,0,bs.Length);
                stream.Close();
            }
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    responseData = reader.ReadToEnd().ToString();
                }
            }
            Console.WriteLine("调用RestTest中Add请求获取结果为：{0}", responseData);
        }

        public static void TestMessageContract(HomeServiceClient homeService)
        {
            int a, b, c;
            a = homeService.PostMessageContract("1.1.1.1", new DateTest() { StrLength = 322 }, 1988, out b, out c);
            Console.WriteLine("TestMessageContract获取的结果,a:{0},b:{1},c:{2}",a,b,c);
        }

        public static void TestUploadFile(HomeServiceClient homeService)
        {
            FileStream fileStream = new FileStream("ccc.txt",FileMode.Open);
            homeService.UploadFile(fileStream);
            Console.WriteLine("TestUploadFile上传文件成功");
        }

        public static void TestUploadFileWithMessageContract(HomeServiceClient homeService)
        {
            using (FileStream fileStream = new FileStream("第二个上传.docx", FileMode.Open))
            {
                homeService.UploadFileWithMessageContract(Path.GetFileName(fileStream.Name), fileStream);
                Console.WriteLine("TestUploadFileWithMessageContract上传文件成功");
            }
        }

        public static void TestTCPService()
        {
            var tcpService = new TCPService.Service1Client();
            tcpService.StartSession();
            tcpService.SetData("gao");
            var result = tcpService.GetData() + "," + tcpService.GetData();
            tcpService.SetData("feng");
            result = result + "," + tcpService.GetData();
            tcpService.EndSession();
            Console.WriteLine("TestTCPService中GetData返回值为{0}",result);
        }
    }
}
