using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn.CustomConvert
{
    public class ExoticType
    {
        private string name;

        public ExoticType(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

    }
}
