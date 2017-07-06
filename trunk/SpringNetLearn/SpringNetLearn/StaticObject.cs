using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public class StaticObject : IWrite
    {
        public string name { get; set; }
        public void Write()
        {
            Console.WriteLine(string.Format("我是通过静态类创建，我是：{0}",this.name));
        }
    }
}
