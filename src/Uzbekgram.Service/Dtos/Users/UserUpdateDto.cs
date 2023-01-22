using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Entities.Users;
using Uzbekgram.Domain.Enums;
using Uzbekgram.Service.Common.Attributes;

namespace Uzbekgram.Service.Dtos.Users
{
    public class UserUpdateDto
    {
        public string? Fullname { get; set; }

        public string? Bio { get; set; }

        public string? Username { get; set; }

        [MaxFileSize(2), AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
        public IFormFile? Image { get; set; }

        public static implicit operator User(UserUpdateDto dto)
        {
            return new User()
            {
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
