using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.DTOs.Authentication
{
    public class LoginResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

    }
}
