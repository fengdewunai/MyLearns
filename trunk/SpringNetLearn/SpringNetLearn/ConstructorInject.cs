using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public class ConstructorInject : IWrite
    {
        public IDao Obj { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        /// <summary>
        /// 构造函数注入时注意，参数名称要与属性名称相同，不用区分大小写，否则报错
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        public ConstructorInject(IDao obj, string name, int value)
        {
            this.Obj = obj;
            this.Name = name;
            this.Value = value;
        }

        public void Write()
        {
            Console.WriteLine(string.Format("当前构造函数注入字符串为：{0}，当前构造函数注入对象为：{1}，当前构造函数注入数值为：{2}", this.Name, this.Obj.ToString(),this.Value));
        }
    }
}
