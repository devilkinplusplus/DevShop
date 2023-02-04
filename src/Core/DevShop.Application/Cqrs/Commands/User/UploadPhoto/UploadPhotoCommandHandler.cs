using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DevShop.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DevShop.Application.Cqrs.Commands.User.UploadPhoto
{
    public class UploadPhotoCommandHandler : IRequestHandler<UploadPhotoCommandRequest, UploadPhotoCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        public UploadPhotoCommandHandler(IUserService userService, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
        }

        public async Task<UploadPhotoCommandResponse> Handle(UploadPhotoCommandRequest request, CancellationToken cancellationToken)
        {
            string photoUrl = _userService.AddPhoto(request.Photo,request.WebRootPath);
            string userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _userService.UpdatePhoto(userId,photoUrl);
            return new(){PhotoUrl = photoUrl,Succeeded = true};
        }
    }
}
