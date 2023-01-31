using DevShop.Application.Abstractions.Services;
using DevShop.Application.Helpers.Utilities.FileHelper;
using DevShop.Application.Repositories.Pictures;
using DevShop.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Persistance.Services
{
    public class PictureService:IPictureService
    {
        private readonly IPictureWriteRepository _pictureWrite;
        public PictureService(IPictureWriteRepository pictureWrite)
        {
            _pictureWrite = pictureWrite;
        }

        public async Task<List<Picture>> AddPicture(List<IFormFile> Picture, string webrootpath)
        {
            List<Picture> pics = new();
            
            for (int i = 0; i < Picture.Count; i++)
            {
                var res = Picture[i].UploadPicture(webrootpath);
                Picture image = new()
                {
                    ImageUrl = res,
                };
                var result = await _pictureWrite.AddEntityAsync(image);

                pics.Add(result);
            }

            return pics;
        }
    }
}
