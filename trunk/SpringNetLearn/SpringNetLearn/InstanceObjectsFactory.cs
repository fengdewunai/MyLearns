using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public class InstanceObjectsFactory
    {
        public IWrite CreateInstance()
        {
            return new InstanceObject();
        }
    }
}
