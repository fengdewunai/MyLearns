using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public class AttributeInject:IWrite
    {
        public string value { get; set; }
        public IDao obj { get; set; }
        public string nullObj { get; set; }

        public void Write()
        {
            Console.WriteLine(string.Format("当前注入属性值为：{0}，当前注入属性对象为：{1}，nullObj值为：{2}", this.value, this.obj.ToString(), this.nullObj == null ? "null" : ""));
        }
    }
}
