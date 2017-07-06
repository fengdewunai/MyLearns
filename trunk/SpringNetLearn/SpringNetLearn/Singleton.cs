using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public class Singleton:IWrite
    {
        public int i { get; set; }

        public Singleton()
        {
            Console.WriteLine(string.Format("我是单例模式被创建，只创建1次"));
        }

        public void Write()
        {
            this.i++;
            Console.WriteLine(string.Format("我是单例模式被创建，现在值为{0}", this.i));
        }

        ~Singleton()
        {
            Console.WriteLine(string.Format("我是单例模式被创建，已销毁"));
        }
    }
}
