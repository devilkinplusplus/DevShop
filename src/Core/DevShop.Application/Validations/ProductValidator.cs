using DevShop.Application.Consts;
using DevShop.Domain.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage(ErrorMessages.NotNullException);
            RuleFor(x => x.Title).MaximumLength(50).WithMessage(ErrorMessages.OutOfRangeException);

            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage(ErrorMessages.NotNullException);
            RuleFor(x => x.Description).MaximumLength(150).WithMessage(ErrorMessages.OutOfRangeException);

            RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage(ErrorMessages.NotNullException);
            RuleFor(x => x.Price).GreaterThan(0).WithMessage(ErrorMessages.MinimumValueException);

            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0).WithMessage(ErrorMessages.MinimumValueException);

            RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).WithMessage(ErrorMessages.MinimumValueException);
            RuleFor(x => x.Discount).LessThan(100).WithMessage(ErrorMessages.MaximumValueException);

            RuleFor(x => x.SubCatagoryId).NotNull().NotEmpty().WithMessage(ErrorMessages.NotNullException);
        }
    }
}
