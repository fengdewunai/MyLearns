using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn.Object
{
    public class TypeAliasTest : IWrite
    {
        public void Write()
        {
            Console.WriteLine("我是TypeAliasTest，通过类型别名创建");
        }
    }
}
