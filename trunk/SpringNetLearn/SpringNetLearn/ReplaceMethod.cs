using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    using System.Reflection;

    using Spring.Objects.Factory.Support;
    public class ReplaceMethod : IMethodReplacer
    {
        public object Implement(object target, MethodInfo method, object[] arguments)
        {
            string value = (string)arguments[0];
            Console.WriteLine("我是替换后的方法，第一个参数值为：" + value + "，第二个参为对象：" + arguments[1].ToString());
            return null;
        }
    }
}
