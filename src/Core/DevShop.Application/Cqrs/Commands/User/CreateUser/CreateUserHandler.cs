using DevShop.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.User.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService) => _userService = userService;

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           var response =  await _userService.CreateAsync(new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
            });

            return new() { Message = response.Message,Succeeded = response.Succeeded };
        }
    }
}
