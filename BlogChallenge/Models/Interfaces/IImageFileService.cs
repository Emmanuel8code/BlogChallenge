using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogChallenge.Models.Interfaces
{
    public interface IImageFileService
    {
        public Task<string> UploadImage(FormFile image);
        public void DeleteImage(string imageFileName);
    }
}
