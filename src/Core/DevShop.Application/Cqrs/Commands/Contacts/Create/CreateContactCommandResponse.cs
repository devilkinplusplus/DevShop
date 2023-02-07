using DevShop.Domain.Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Contacts.Create
{
    public class CreateContactCommandResponse
    {
        public bool Succeeded { get; set; }
        public List<ValidationFailure> Errors  { get; set; }
    }
}