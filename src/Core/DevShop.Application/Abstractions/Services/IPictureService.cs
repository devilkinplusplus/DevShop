using DevShop.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Abstractions.Services
{
    public interface IPictureService
    {
        public Task<List<Picture>> AddPicture(List<IFormFile> Picture, string webrootpath);
    }
}
