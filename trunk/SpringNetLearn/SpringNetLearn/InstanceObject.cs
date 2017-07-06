using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public class InstanceObject : IWrite
    {
        public void Write()
        {
            Console.WriteLine("我是通过实例工厂创建");
        }
    }
}
