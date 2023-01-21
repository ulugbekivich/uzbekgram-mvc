using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Service.Common.Attributes;

namespace Uzbekgram.Service.Dtos.Accounts
{
    public class AccountLoginDto
    {
        [Required, Email]
        public string Email { get; set; } = string.Empty;
        [Required, StrongPassword]
        public string Password { get; set; } = string.Empty;
    }
}
