using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn.Object
{
    using Spring.Core.IO;
    using Spring.Objects.Factory;
    using Spring.Objects.Factory.Xml;

    public class ObjectFactoryTest : IWrite
    {
        public void Write()
        {
            IResource input = new FileSystemResource("Objects.xml");
            IObjectFactory factory = new XmlObjectFactory(input);
            //是否包含以某个名称命名的对象
            var isContainsObject = factory.ContainsObject("aaaa");
            //返回以指定名称命名的对象
            var objectA = factory.GetObject<IDao>("dao");
            var objectB = factory.GetObject("dao", typeof(IDao));
            //索引器返回以指定名称命名的对象
            var objectC = factory["dao"] as IDao;
            //是否为单例模式
            var isSingleton = factory.IsSingleton("dao");
            //获取别名
            IList<string> aliases = factory.GetAliases("dao");

            factory.ConfigureObject(new TestInject(), "dao");

           

            Console.WriteLine("isContainsObject值为{0}", isContainsObject);
            Console.WriteLine("objectA值为{0}", objectA);
            Console.WriteLine("objectB值为{0}", objectB);
            Console.WriteLine("objectC值为{0}", objectC);
            Console.WriteLine("isSingleton值为{0}", isSingleton);
            Console.WriteLine("aliases值为{0}", string.Join(",",aliases));

        }
    }
}
