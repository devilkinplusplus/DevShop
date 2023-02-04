using DevShop.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.User.ChangePassword
{
    public class ChangePassCommandRequest:IRequest<ChangePassCommandResponse>
    {
        public ChangePasswordDTO PasswordDTO { get; set; }
    }
}
