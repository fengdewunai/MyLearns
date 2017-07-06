using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public class Dao:IDao
    {
        public class Child : IChild
        {
            public string name { get; set; }
            public void Write()
            {
                Console.WriteLine("Dao中嵌套类Child");
            }
        }
        public void write()
        {
            Console.WriteLine("Dao注入");
        }

        //必须为虚方法或抽象方法
        public virtual void ReplaceMethod(string str, IChild c)
        {
            Console.WriteLine("我是将被替换的方法");
        }
    }
}
