using DevShop.Domain.Entities.Identity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.User.CreateUser
{
    public class CreateUserCommandResponse
    {
        public AppUser User { get; set; }
        public bool Succeeded { get; set; }
        public IEnumerable<IdentityError> Messages { get; set; }
        public List<ValidationFailure> Errors { get; set; }

    }
}
