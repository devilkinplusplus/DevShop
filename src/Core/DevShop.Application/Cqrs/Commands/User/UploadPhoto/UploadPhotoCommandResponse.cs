using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.User.UploadPhoto
{
    public class UploadPhotoCommandResponse
    {
        public string PhotoUrl { get; set; }
        public bool Succeeded { get; set; }
    }
}
