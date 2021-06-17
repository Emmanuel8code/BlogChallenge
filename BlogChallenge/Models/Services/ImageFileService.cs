using BlogChallenge.Models.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Models.Services
{
    public class ImageFileService : IImageFileService
    {
        private readonly IWebHostEnvironment _environment;
        public ImageFileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> UploadImage(FormFile image)
        {
            //string[] permittedExtensions = { ".jpg", ".png", ".svg" };
            string imagesFolderPath = _environment.WebRootPath + "\\Images\\";
            string imageFileName = image.FileName + DateTime.UtcNow.ToString();
     
            try
            {
                //var ext = Path.GetExtension(objImage.FileName).ToLowerInvariant();

                //if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                //{
                //    throw new InvalidDataException(string.Format("Invalid file extension"));
                //}

                if (!Directory.Exists(imagesFolderPath))
                {
                    Directory.CreateDirectory(imagesFolderPath);
                }

                using (FileStream fileStream = File.Create(imagesFolderPath + imageFileName))
                {
                    await image.CopyToAsync(fileStream);
                    fileStream.Flush();
                }

                return imageFileName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteImage(string image)
        {
            throw new NotImplementedException();
        }
    }
}
