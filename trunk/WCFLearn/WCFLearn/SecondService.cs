using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    public class SecondService : ISecondService
    {
        public int GetStrLength(string str)
        {
            return str.Length;
        }
    }
}
