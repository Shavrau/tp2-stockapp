using FluentAssertions;
using StockApp.Domain.Entities;
using Xunit;

namespace StockApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos
        [Fact(DisplayName = "Create Category With Invalid State")]
        public void CreateCategory_WithValidParameters_DomainExceptionInValidId()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");

        }
        [Fact(DisplayName = "Create Category With Invalid State name")]
        public void CreateCategory_WithValidParameters_DomainExceptionInValidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Category With Null State name")]
        public void CreateCategory_WithNullParameters_DomainExceptionInValidId()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");

        }
        #endregion
    }
}