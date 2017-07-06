using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn.Object
{
    public class TestInject : IWrite
    {
        public TestInject()
        {
            Console.WriteLine("TestInject已调用构造函数");
        }

        public void Write()
        {
            Console.WriteLine("我是TestInjectA");
        }

        public void Init()
        {
            Console.WriteLine("我是TestInjectA的初始化方法");
        }
    }
}
