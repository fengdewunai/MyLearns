using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public class Parents:IWrite
    {
        public string Name;

        public void Write()
        {
            Console.WriteLine("我是Parent，姓：" + this.Name);
        }
    }
}
