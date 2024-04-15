using FluentAssertions;
using StockApp.Domain.Entities;

namespace Stockapp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Positivos
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product("Name", "Description", 1, 1, "Image", 1);
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Valid State, Decimal price")]
        public void CreateProduct_WithDecimalPrice_ResultValidState()
        {
            Action action = () => new Product("Name", "Description", 1.22m, 1, "Image", 1);
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region Negativos
        [Fact(DisplayName = "Create Product With Invalid State Name")]
        public void CreateProduct_WithInValidParameters_DomainExceptionInValidName()
        {
            Action action = () => new Product("Na", "Description", 1, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Null State Name")]
        public void CreateProduct_WithNullParameters_DomainExceptionInValidName()
        {
            Action action = () => new Product("", "Description", 1, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Name")]
        public void CreateProduct_WithInValidParameters_DomainExceptionInValidNameLength()
        {
            Action action = () => new Product("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium q", "Description", 1, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too long, maximum 100 characters.");
        }

        [Fact(DisplayName = "Create Product With Null State Description")]
        public void CreateProduct_WithNullParameters_DomainExceptionInValidDescription()
        {
            Action action = () => new Product("Name", "", 1, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Description")]
        public void CreateProduct_WithInValidParameters_DomainExceptionInValidDescription()
        {
            Action action = () => new Product("Name", "Desc", 1, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Price")]
        public void CreateProduct_WithInValidParameters_DomainExceptionInValidPrice()
        {
            Action action = () => new Product("Name", "Description", -1, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Price Decimal Places")]
        public void CreateProduct_WithInValidParameters_DomainExceptionInValidPriceDecimalPlaces()
        {
            Action action = () => new Product("Name", "Description", 1.123m, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price, invalid decimal places.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Stock")]
        public void CreateProduct_WithInValidParameters_DomainExceptionInValidStock()
        {
            Action action = () => new Product("Name", "Description", 1, -1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Image")]
        public void CreateProduct_WithInValidParameters_DomainExceptionInValidImage()
        {
            Action action = () => new Product("Name", "Description", 1, 1, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium q", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }
        #endregion
    }
}