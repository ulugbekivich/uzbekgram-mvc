using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Common;
using Uzbekgram.Domain.Enums;

namespace Uzbekgram.Domain.Entities.Users
{
    public class User : Audiable
    {
        public string Fullname { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        public string? Usermame { get; set; }


        public UserStatus userStatus { get; set; }

        public string ImagePath { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool EmailVerifed { get; set; } = false;

        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
    }
}
