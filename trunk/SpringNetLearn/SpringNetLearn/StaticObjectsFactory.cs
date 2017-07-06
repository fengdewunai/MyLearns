using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public static class StaticObjectsFactory
    {
        public static IWrite CreateInstance()
        {
            var obj = new StaticObject();
            obj.name = "哈哈哈";
            return obj;
        }
    }
}
