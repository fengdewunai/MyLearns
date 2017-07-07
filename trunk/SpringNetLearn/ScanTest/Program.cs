using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanTest
{
    using Microsoft.Practices.ServiceLocation;

    using Spring.Context.Support;

    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new CodeConfigApplicationContext();
            ctx.ScanAllAssemblies();
            ctx.Refresh();
            ServiceLocator.SetLocatorProvider(() => new SpringServiceLocatorAdapter(ctx));

            var actionTest = ServiceLocator.Current.GetInstance<IActionTest>();
            //var actionTest = ctx.GetObject<IActionTest>("ccc");
            actionTest.DoSomething();

            Console.ReadKey();
        }
    }
}
