using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Carts.Create
{
    public class CreateCartCommandResponse
    {
        public bool Succeeded { get; set; }
    }
}
