using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanTest
{
    using Spring.Context.Attributes;
    using Spring.Objects.Factory.Attributes;

    [Configuration]
    public class Bll : IBll
    {
        [Autowired]
        private IDao dao;

        public int Get()
        {
            return this.dao.Get();
        }

        public void Save()
        {
            this.dao.Save();
        }
    }
}
