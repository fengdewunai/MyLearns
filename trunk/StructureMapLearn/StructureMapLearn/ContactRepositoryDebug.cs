using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureMapLearn
{
    class ContactRepositoryDebug:IContactRepository
    {
        public void Save()
        {
            Console.WriteLine("ContactRepositoryDebug:Save()");
        }
    }
}
