using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Entities.Users;
using Uzbekgram.Service.Common.Attributes;

namespace Uzbekgram.Service.Dtos.Accounts
{
    public class AccountRegisterDto
    {
        [Required, MaxLength(60), MinLength(1)]
        public string FullName { get; set; } = string.Empty;

        [Required, Email]
        public string Email { get; set; } = string.Empty;

        [Required, StrongPassword]
        public string Password { get; set; } = string.Empty;

        public static implicit operator User(AccountRegisterDto accountRegisterDto)
        {
            return new User()
            {
                Fullname = accountRegisterDto.FullName,
                Email = accountRegisterDto.Email
            };
        }
    }
}
