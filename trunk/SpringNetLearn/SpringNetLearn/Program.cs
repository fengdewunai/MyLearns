using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    using System.Runtime.InteropServices;
    using System.Threading;

    using Microsoft.Practices.ServiceLocation;

    using Spring.Context;
    using Spring.Context.Support;
    using Spring.Objects.Factory;
    using Spring.Objects.Factory.Config;

    using SpringNetLearn.Object;
    using SpringNetLearn.ReferenceOther;

    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("容器初始化。。。");
            IApplicationContext ctx = ContextRegistry.GetContext("ParentContext");
            ServiceLocator.SetLocatorProvider(() => new SpringServiceLocatorAdapter(ctx));
            Console.WriteLine("容器初始化完成");
            //var dao = ctx.GetObject("dao") as IDao;
            var dao = ServiceLocator.Current.GetInstance<IDao>();
            //嵌套类注入
            //var child = ctx.GetObject("dao_child") as IChild;
            ////泛型注入
            //var generic = ctx.GetObject("generic") as IGenericClass;
            ////静态工厂
            //var staticObject = ctx.GetObject("staticObject") as IWrite;
            ////实例工厂
            //var instanceObject = ctx.GetObject("instanceObject") as IWrite;
            ////延迟加载
            //var lazyCreate = ctx.GetObject("lazyCreate") as IWrite;
            ////属性注入
            //var attributeInject = ctx.GetObject("attributeInject") as IWrite;
            ////设置索引器属性
            //var indexObject = ctx.GetObject("indexObject") as IWrite;
            ////构造函数注入
            //var constructorInject = ctx.GetObject("constructorInject") as IWrite;
            ////集合注入
            //var collectionInject = ctx.GetObject("collectionInject") as IWrite;
            ////查询方法
            //var abstractMethod = (AbstractMethod)ctx.GetObject("abstractMethod");
            ////替换方法
            //var replaceMethod = ctx.GetObject("dao") as IDao;
            ////事件注入
            //var door = (Door)ctx.GetObject("door");
            ////继承
            //var children = ctx.GetObject("children") as IWrite;
            ////通过其他对象属性或字段注入
            //var targetObject = ctx.GetObject("targetObject") as IWrite;
            ////自定义类型转换器
            //var dependsOnExoticType = ctx.GetObject("dependsOnExoticType") as IWrite;
            ////IObjectFactory常用方法
            //var objectFactoryTest = new ObjectFactoryTest();
            ////对象后处理器
            //var postInject = ctx.GetObject("postInject") as IWrite;
            ////工厂后处理器
            //var propertyPlaceholderTest = ctx.GetObject("propertyPlaceholderTest") as IWrite;
            ////类型别名
            //var typeAlias = ctx.GetObject("typeAlias") as IWrite;
            

            TestSingleton(ctx);

            dao.write();
            //child.Write();
            //generic.Write();
            //staticObject.Write();
            //instanceObject.Write();
            //attributeInject.Write();
            //indexObject.Write();
            //constructorInject.Write();
            //collectionInject.Write();
            //Console.WriteLine("查询方法注入：" + abstractMethod.GetDao().ToString());
            //replaceMethod.ReplaceMethod("aaa",new Dao.Child());
            //door.OnOpen("卧室门开了");;
            //children.Write();
            //targetObject.Write();
            ////通过其他对象方法结果注入
            //var dependOther = ctx.GetObject("dependOther");
            //dependsOnExoticType.Write();
            //objectFactoryTest.Write();
            //postInject.Write();
            //propertyPlaceholderTest.Write();
            //typeAlias.Write();

            Console.ReadLine();

        }

        public static void TestSingleton(IApplicationContext ctx)
        {
            var singleton1 = ctx.GetObject("singleton") as IWrite;
            var singleton2 = ctx.GetObject("singleton") as IWrite;
            var notSingleton1 = (NotSingleton)ctx.GetObject("notSingleton");
            var notSingleton2 = (NotSingleton)ctx.GetObject("notSingleton");
            singleton1.Write();
            singleton2.Write();
            notSingleton1.Write();
            notSingleton2.Write();
        }
    }
}
