<<<<<<< HEAD
﻿using StockApp.Domain.Validation;
using System;
=======
﻿using System;
>>>>>>> e5d107ecfa172be473d2a075501cdf8113a2fc87
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class Product
    {
<<<<<<< HEAD
        #region Atributos
=======
>>>>>>> e5d107ecfa172be473d2a075501cdf8113a2fc87
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
<<<<<<< HEAD
        public int Stock { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        #endregion

        public Product()
        {

        }
        public Category Category { get; set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short minimum 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description, name is required.");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short minimum 5 characters.");

        }
=======
        public int Stock { get; set;}
        public string Image { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
>>>>>>> e5d107ecfa172be473d2a075501cdf8113a2fc87
    }
}