using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    using Spring.Expressions;

    public class CollectionInject : IWrite
    {
        public List<object> ListObj { get; set; }
        public Dictionary<int,object> DicObj { get; set; }

        public void Write()
        {
            Console.WriteLine("以下为List中内容");
            foreach (var item in this.ListObj)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("以下为Dictionary中内容");
            foreach (var item in this.DicObj)
            {
                Console.WriteLine("key为{0}，value为{1}", item.Key, ((IExpression)item.Value).GetValue());
            }
        }
    }
}
