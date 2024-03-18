using Microsoft.VisualBasic;
<<<<<<< HEAD
using StockApp.Domain.Validation;
=======
>>>>>>> e5d107ecfa172be473d2a075501cdf8113a2fc87
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class Category
    {
<<<<<<< HEAD
        #region Atributos

        public int Id { get; set;  }
        public string Name { get; set; }

        #endregion

        #region Construtores
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id , string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        #endregion

        #region Validação

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short minimum 3 characters.") ;

            Name = name;   
        }
        #endregion
=======
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Product> Products { get; set; }
>>>>>>> e5d107ecfa172be473d2a075501cdf8113a2fc87
    }
}
