using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanTest
{
    using Spring.Context.Attributes;

    [Configuration]
    public class Dao : IDao
    {
        public int Get()
        {
            Console.WriteLine("已获取到数据");
            return 1;
        }

        public void Save()
        {
            Console.WriteLine("保存成功");
        }
    }
}
