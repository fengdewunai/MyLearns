using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    using System.Net;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Threading;

    using WCFClient.HomeService;
    using WCFClient.SecondService;

    class Program
    {
        static void Main(string[] args)
        {
            var homeService = new HomeServiceClient();
            Console.WriteLine(homeService.GetLength("gaofeng"));

            var secondService = new SecondServiceClient();
            Console.WriteLine(secondService.GetStrLength("jiajia"));
            TestChannel();
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
    }
}
