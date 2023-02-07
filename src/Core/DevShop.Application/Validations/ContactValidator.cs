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
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Subject).MaximumLength(255).WithMessage(ErrorMessages.MaximumValueException);
            RuleFor(x => x.Message).NotEmpty().NotNull().WithMessage(ErrorMessages.NotNullException);
            RuleFor(x => x.Message).MaximumLength(1000).WithMessage(ErrorMessages.MaximumValueException);
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage(ErrorMessages.NotNullException);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ErrorMessages.InvalidMailException);
        }
    }
}
