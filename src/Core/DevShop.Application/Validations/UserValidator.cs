﻿using DevShop.Application.Consts;
using DevShop.Domain.Entities.Identity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Validations
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage(ErrorMessages.NotNull);
            RuleFor(x=>x.FirstName).MinimumLength(2).MaximumLength(20).WithMessage(ErrorMessages.FirstNameOutOfRange);

            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage(ErrorMessages.NotNull);
            RuleFor(x => x.LastName).MinimumLength(2).MaximumLength(26).WithMessage(ErrorMessages.LastNameOutOfRange);

            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage(ErrorMessages.NotNull);
            RuleFor(x => x.Email).EmailAddress().WithMessage(ErrorMessages.InvalidMail);

            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage(ErrorMessages.NotNull);
            RuleFor(x=>x.UserName).MinimumLength(1).MaximumLength(16).WithMessage(ErrorMessages.UserNameOutOfRange);

        }
    }
}
