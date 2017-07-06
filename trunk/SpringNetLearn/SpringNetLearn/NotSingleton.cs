using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public class NotSingleton : IWrite
    {
        public int i { get; set; }

        public NotSingleton()
        {
            Console.WriteLine(string.Format("我是非单例模式被创建"));
        }

        public void Write()
        {
            this.i++;
            Console.WriteLine(string.Format("我是非单例模式被创建，现在值为{0}", this.i));
        }

        //创建后执行
        public void Init()
        {
            Console.WriteLine("我已经被创建了");
        }

        //销毁后执行
        public void Destroy()
        {
            Console.WriteLine("我已经被销毁了");
        }

        ~NotSingleton()
        {
            Console.WriteLine(string.Format("我是非单例模式被创建，已销毁"));
        }
    }
}
