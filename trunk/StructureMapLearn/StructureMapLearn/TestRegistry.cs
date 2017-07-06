using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureMapLearn
{
    using StructureMap.Configuration.DSL;

    public class TestRegistry:Registry
    {
        public TestRegistry()
        {
            //this.For<IContactValidator>().Use<ContactValidator>();
            //this.For<IContactRepository>().Use<ContactRepository>();
        }
    }
}
