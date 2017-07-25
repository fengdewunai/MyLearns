using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    using System.ServiceModel;

    public class SecondService : ISecondService
    {
        public int GetStrLength(string str)
        {
            int index = OperationContext.Current.IncomingMessageHeaders.FindHeader("header", "http://my");
            if (index != -1)
            {
                string hd = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>(index);
                Console.WriteLine("收到的标头：{0}", hd);
            }  
            return str.Length;
        }
    }
}
