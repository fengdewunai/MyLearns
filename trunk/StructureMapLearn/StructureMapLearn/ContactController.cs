using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureMapLearn
{
    public class ContactController
    {
        private IContactValidator _validator;
        private IContactRepository _repository;
        public ContactController(IContactValidator validator, IContactRepository repository)
        {
            this._repository = repository;
            this._validator = validator;
        }

        public void Save()
        {
            this._validator.Validate();
            this._repository.Save();
        }
    }
}
