using FluentAssertions;
using StockApp.Domain.Entities;

namespace Stockapp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Positivos
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region Negativos
        [Fact(DisplayName = "Create Category With Invalid State Id")]
        public void CreateCategory_WithInValidParameters_DomainExceptionInValidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");          
        }

        [Fact(DisplayName = "Create Category With Invalid State Name")]
        public void CreateCategory_WithInValidParameters_DomainExceptionInValidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }
        [Fact(DisplayName = "Create Category With Null State Id")]
        public void CreateCategory_WithNullParameters_DomainExceptionInValidName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }
        #endregion
    }
}