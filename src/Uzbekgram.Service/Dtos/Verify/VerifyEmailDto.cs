using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Service.Common.Attributes;

namespace Uzbekgram.Service.Dtos.Verify
{
    public class VerifyEmailDto
    {
        [Required, Email]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int Code { get; set; }
    }
}
