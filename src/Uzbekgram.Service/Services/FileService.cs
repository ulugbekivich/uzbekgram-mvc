using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Service.Interfaces;

namespace Uzbekgram.Service.Services
{
    public class FileService : IFileService
    {
        public Task<string> SaveImageAsync(IFormFile image)
        {
            throw new NotImplementedException();
        }
    }
}
