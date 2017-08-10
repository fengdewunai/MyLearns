using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    public class MyCallback : TCPService.IService1Callback
    {
        // 因为该方法是由服务器调用的  
        // 如果希望在客户端能即时作出响应  
        // 应当使用事件  
        public void CallClient(int v)
        {
            Console.WriteLine("执行回调方法，返回值为{0}", v);
            //if (this.ValueCallbacked != null)
            //{
            //    this.ValueCallbacked(this, v);
            //}
        }  

        /// <summary>  
        /// 回调引发该事件  
        /// </summary>  
        public event EventHandler<int> ValueCallbacked;  
    }
}
