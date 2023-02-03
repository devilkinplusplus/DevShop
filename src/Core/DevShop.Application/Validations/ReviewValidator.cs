using DevShop.Application.Consts;
using DevShop.Domain.Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Validations
{
    public class ReviewValidator:AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(x => x.Comment).NotEmpty().NotNull().WithMessage(ErrorMessages.NotNullException);
            RuleFor(x => x.Comment).MaximumLength(100).WithMessage(ErrorMessages.MaximumValueException);
            RuleFor(x => x.Rating).NotEmpty().NotNull().WithMessage(ErrorMessages.NotNullException);
            RuleFor(x => x.Rating).LessThanOrEqualTo(5).WithMessage(ErrorMessages.MaximumReviewException);
        }
    }
}
