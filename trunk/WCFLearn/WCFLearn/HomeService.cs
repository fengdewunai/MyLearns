using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    using System.IO;
    using System.ServiceModel.Channels;

    public class HomeService:IHomeService
    {

        public string GetLength(string name)
        {
            return "名字长度："+ name.Length.ToString();
        }

        public void GetDataContract(DateTest dateTest)
        {
            Console.WriteLine("HomeService收到传来的GetDataContract请求，DateTest实体信息：{0}", dateTest.StrLength);
        }

        public Message TestMessage(Message message)
        {
            var header = message.Headers;
            var ip = header.GetHeader<string>("ip", string.Empty);
            var body = message.GetBody<string>();
            Console.WriteLine("HomeService收到TestMessage请求，客户端的IP=" + ip);
            return Message.CreateMessage(message.Version, message.Headers.Action + "Response", body.Length);
        }

        public ResponseMessage PostMessageContract(CarMessage msg)
        {
            Console.WriteLine("测试消息协定，收到CarMessage消息，IP：{0}", msg.IP);
            return new ResponseMessage(){a=1,b=2,c=3};
        }

        public void UploadFile(Stream inputStream)
        {
            using (FileStream fileStream = new FileStream("aaa.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                inputStream.CopyTo(fileStream);
                fileStream.Flush();
                Console.WriteLine("HomeService收到UploadFile请求，已收到文件");
            }
        }

        public void UploadFileWithMessageContract(TransferFileMessage msg)
        {
            using (FileStream fileStream = new FileStream(msg.FileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                msg.FileStream.CopyTo(fileStream);
                fileStream.Flush();
                Console.WriteLine("HomeService收到UploadFileWithMessageContract请求，已收到文件");
                msg.FileStream.Close();
            }
        }

    }
}
