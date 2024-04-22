using StockApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class Product
    {
        #region Atributos
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        #endregion


        public Product(int v, string v1)
        {

        }

        public Product(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            Name = name;
            Description= description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        public Category Category { get; set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {

            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            DomainExceptionValidation.When(name.Length > 100,
                    "Invalid name, too big, maximum 100 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(image),
                "Invalid image name, image is required.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description, name is required.");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters.");

            DomainExceptionValidation.When(image.Length > 250, "Invalid image name, too long, maximum 250 characters.");

            DomainExceptionValidation.When(price < 0, "Invalid price negative value.");

            DomainExceptionValidation.When(Decimal.Round(price, 2) != price, "Invalid decimal places, invalid price.");

            DomainExceptionValidation.When(stock < 0, "Invalid stock, value negative.");

        }
    }
}