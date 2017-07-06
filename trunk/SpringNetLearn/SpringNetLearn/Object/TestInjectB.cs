using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn.Object
{
    public class TestInjectB : IWrite
    {
        public TestInjectB()
        {
            Console.WriteLine("TestInjectB已调用构造函数");
        }

        public void Write()
        {
            Console.WriteLine("我是TestInjectB ");
        }

        public void Init()
        {
            Console.WriteLine("我是TestInjectB的初始化方法");
        }
    }
}
