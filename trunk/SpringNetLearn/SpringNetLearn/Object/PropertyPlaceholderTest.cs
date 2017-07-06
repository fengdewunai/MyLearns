using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn.Object
{
    public class PropertyPlaceholderTest:IWrite
    {
        public int MaxLength { get; set; }

        public string names { get; set; }

        public string path { get; set; }

        public string Sex { get; set; }

        public void Write()
        {
            Console.WriteLine("PropertyPlaceholderConfigurer测试，MaxLength值为{0}，names值为{1}，path值为{2}，Sex值为{3}", this.MaxLength, this.names, this.path, this.Sex);
        }
    }
}
