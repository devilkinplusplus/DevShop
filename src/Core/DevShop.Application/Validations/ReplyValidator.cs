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
    public class ReplyValidator:AbstractValidator<Reply>
    {
        public ReplyValidator()
        {
            RuleFor(x => x.Message).NotNull().NotEmpty().WithMessage(ErrorMessages.NotNullException);
            RuleFor(x => x.Message).MaximumLength(1000).WithMessage(ErrorMessages.MaximumValueException);
        }
    }
}
