using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public class GenericClass<T> : IGenericClass
    {
        public void Write()
        {
            T value = default(T);
            Console.WriteLine(string .Format("泛型类注入，类型默认值为{0}",value));
        }
    }
}
