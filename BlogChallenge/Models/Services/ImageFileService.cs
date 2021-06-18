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
        private readonly string _imagesFolderPath;  
        public ImageFileService(IWebHostEnvironment environment)
        {
            _environment = environment;
            _imagesFolderPath = _environment.WebRootPath + "\\Images\\";
        }

        public async Task<string> UploadImage(IFormFile image)
        {
            //string[] permittedExtensions = { ".jpg", ".png", ".svg" };
            
            string imageFileName = image.FileName;
     
            try
            {
                //var ext = Path.GetExtension(objImage.FileName).ToLowerInvariant();

                //if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                //{
                //    throw new InvalidDataException(string.Format("Invalid file extension"));
                //}

                if (!Directory.Exists(_imagesFolderPath))
                {
                    Directory.CreateDirectory(_imagesFolderPath);
                }

                using (FileStream fileStream = File.Create(_imagesFolderPath + imageFileName))
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

        public void DeleteImage(string imageFileName)
        {
            if (Directory.Exists(_imagesFolderPath))
            {
                File.Delete(_imagesFolderPath + imageFileName);
            }
        }
    }
}
