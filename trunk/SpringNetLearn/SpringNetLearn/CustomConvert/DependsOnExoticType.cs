using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn.CustomConvert
{
    public class DependsOnExoticType : IWrite
    {
        private ExoticType exoticType;

        public ExoticType ExoticType
        {
            get { return this.exoticType; }
            set { this.exoticType = value; }
        }

        public void Write()
        {
            Console.WriteLine("通过自定义类型转换器转换后值为:{0}", this.exoticType.Name);
        }

    }
}
