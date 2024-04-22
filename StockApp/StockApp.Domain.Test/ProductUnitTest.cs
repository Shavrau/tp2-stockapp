using FluentAssertions;
using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos

        [Fact(DisplayName = "Create Product With Valid State")]
        public void
            CreateProduct_WithValidParameters_ResultValidname()
        {
            Action action = () => new Product("Name", "Description", 1, 1, "Image", 1);
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Valid State, Decimal price")]
        public void
             CreateProduct_WithDecimalPrice_ResultValidState()
        {
            Action action = () => new Product("Name", "Description", 1.99m, 1, "Image", 1);
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }


        #endregion

        #region Teste Negativo Nome

        [Fact(DisplayName = "Create Product With Invalid State")]
        public void
    CreateProduct_WithValidParameters_DomainExceptionInValidname()
        {
            Action action = () => new Product("Ca", "Description", 1, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Null State Name")]
        public void
      CreateProduct_WithNullParameters_DomainExceptionInValidName()
        {
            Action action = () => new Product(null, "Description", 1, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        #endregion

        #region Teste Negativo Descrição

        [Fact(DisplayName = "Create Product With Invalid State Description")]
        public void
     CreateProduct_WithInValidParameters_DomainExceptionInValidDescription()
        {
            Action action = () => new Product("Name", "Test", 1, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        #endregion

        #region	Teste Negativo de URL da Imagem

        [Fact(DisplayName = "Create Product With Invalid State Image")]
        public void
         CreateProduct_WithInValidParameters_DomainExceptionInValidImage()
        {
            Action action = () => new Product("Name", "Description", 1, 1, "This is a long image name that exceeds the maximum length allowThis is a long image name that exceeds the maximum length allowThis is a long image name that exceeds the maximum length allowThis is aThis is a long image name that exceeds the maximum length allowThis is a long image name that exceeds the maximum length allow long image name that exceeds the maximum length allowed by the system. It should contain at least 250 characters to trigger the validation error.This is a long image name that exceeds the maximum length allowThis is a long image name that exceeds the maximum length allowThis is a long image name that exceeds the maximum length allowThis is a long image name that exceeds the maximum length allowThis is a long image name that exceeds the maximum length allowThis is a long image name that exceeds the maximum length allowThis is a long image name that exceeds the maximum length allowThis is a long image name that exceeds the maximum length allowThis is a long image name that exceeds the maximum length allow", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        #endregion 

        #region Teste Negativo de Preço


        [Fact(DisplayName = "Create Product With Invalid State Price")]
        public void
    CreateProduct_WithInValidParameters_DomainExceptionInValidPrice()
        {
            Action action = () => new Product("Name", "Description", -1, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Price Decimal Places")]
        public void
    CreateProduct_WithInValidParameters_DomainExceptionInValidPriceDecimalPlaces()
        {
            Action action = () => new Product("Name", "Description", 9.999m, 1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid decimal places, invalid price.");
        }

        #endregion

        #region Teste Negativo de Quantidade

        [Fact(DisplayName = "Create Product With Invalid State Stock")]
        public void
    CreateProduct_WithInValidParameters_DomainExceptionInValidStock()
        {
            Action action = () => new Product("Name", "Description", 1, -1, "Image", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock, value negative.");
        }

        #endregion
    }
}