using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn.ReferenceOther
{
    public class TargetObject : IWrite
    {
        public int age = 11;

        public string Name { get; set; }

        public string Sex { get; set; }

        public void Write()
        {
            Console.WriteLine("从SourceObject对象获取的Sex值为{0}，age值为 {1}", this.Sex, this.age);
        }

        public static void StaticMethod(string s)
        {
            Console.WriteLine("我是静态方法结果注入，参数为：{0}",s);
        }

        public void NotStaticMethod(string name, params string[] work)
        {
            Console.WriteLine("我是非静态方法结果注入，姓名为：{0}，工作为：{1}", name, string.Join(",",work));
        }
    }
}
