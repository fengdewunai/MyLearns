using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureMapLearn
{
    public class ContactValidator : IContactValidator
    {
        public void Validate()
        {
            Console.WriteLine("IContactValidator:ContactValidator");
        }
    }
}
