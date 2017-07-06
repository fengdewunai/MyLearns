using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    using System.ServiceModel.Channels;

    public class HomeService:IHomeService
    {

        public string GetLength(string name)
        {
            return "名字长度："+ name.Length.ToString();
        }

        public Message TestMessage(Message message)
        {
            var header = message.Headers;
            var ip = header.GetHeader<string>("ip", string.Empty);
            var body = message.GetBody<string>();
            Console.WriteLine("客户端的IP=" + ip);
            return Message.CreateMessage(message.Version, message.Headers.Action + "Response", body.Length);
        }

    }
}
