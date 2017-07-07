using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanTest
{
    public interface IDao
    {
        int Get();

        void Save();
    }
}
