using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Helpers.Utilities.FileHelper
{
    public static class PictureHelper
    {
        public static string UploadPicture(this IFormFile file, string webRootPath)
        {
            var path = "/images/products/" + Guid.NewGuid().ToString() + file.FileName;
            using (var fileStream = new FileStream(webRootPath + path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return path;
        }
    }
}
