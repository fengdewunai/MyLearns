using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    public interface IDao
    {
        void write();

        void ReplaceMethod(string str, IChild c);


    }
}
