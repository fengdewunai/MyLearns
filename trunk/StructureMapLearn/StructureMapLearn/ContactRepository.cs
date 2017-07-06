using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureMapLearn
{
    public class ContactRepository : IContactRepository
    {
        public ContactRepository(int a)
        {
            
        }
        public void Save()
        {
            Console.WriteLine("ContactRepository:Save()");
        }
    }
}
