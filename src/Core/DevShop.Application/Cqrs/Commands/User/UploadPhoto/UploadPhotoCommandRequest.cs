using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.User.UploadPhoto
{
    public class UploadPhotoCommandRequest:IRequest<UploadPhotoCommandResponse>
    {
        public IFormFile Photo { get; set; }
        public string WebRootPath { get; set; }
    }
}
