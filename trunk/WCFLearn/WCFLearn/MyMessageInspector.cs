using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;
    public class MyMessageInspector:IClientMessageInspector,IDispatchMessageInspector
    {

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            Console.WriteLine("客户端接收到的回复：\n{0}", reply.ToString());  
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            //Console.WriteLine("客户端发送请求前的SOAP消息：\n{0}", request.ToString());
            //MessageHeader hdUserName = MessageHeader.CreateHeader("u", "fuck", "admin");
            //MessageHeader hdPassWord = MessageHeader.CreateHeader("p", "fuck", "123");
            //request.Headers.Add(hdUserName);
            //request.Headers.Add(hdPassWord);  
            return null;  
        }

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            //Console.WriteLine("服务器端：接收到的请求：\n{0}", request.ToString());
            //string un = request.Headers.GetHeader<string>("u", "fuck");
            //string ps = request.Headers.GetHeader<string>("p", "fuck");  
            return null;  
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            Console.WriteLine("服务器即将作出以下回复：\n{0}", reply.ToString());  
        }
    }
}
