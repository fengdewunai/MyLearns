using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanTest
{
    using Spring.Context.Attributes;
    using Spring.Objects.Factory.Attributes;

    [Configuration("ccc")]
    public class ActionTest : IActionTest
    {
        [Autowired]
        private IBll bll{ get; set; }

        public void DoSomething()
        {
            bll.Get();
            bll.Save();
        }
    }
}
