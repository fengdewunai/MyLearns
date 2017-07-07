using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanTest
{
    using Spring.Context.Attributes;

    
    public class BllB : IBll
    {
        public int Get()
        {
            Console.Write("我是BllB，获取对象成功");
            return 1;
        }

        public void Save()
        {
            Console.Write("我是BllB,保存成功");
        }
    }
}
