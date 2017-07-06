using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public class LazyCreate : IWrite
    {
        public LazyCreate()
        {
            Console.WriteLine("我是单例模式，但是延迟实例化");
        }

        public void Write()
        {
            Console.WriteLine("我是单例模式，但是延迟实例化");
        }
    }
}
