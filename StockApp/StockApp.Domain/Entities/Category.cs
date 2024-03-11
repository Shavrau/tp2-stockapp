using StockApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    #region Atributos
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion
    #region Construtores
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            id = Id;
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }
        #endregion
    #region Validações
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Invalid name, name is required");

            DomainExceptionValidation.When(name.Length < 3, 
                "Invalid name, too short, minimum 3 characters.");

            Name = name;
        }
        #endregion
    }
}
