using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Entities.Users;
using Uzbekgram.Service.Common.Attributes;

namespace Uzbekgram.Service.Dtos.MediaMessages
{
    public class CreateMediMessageDto
    {
        [Required, Integer]
        public long SenderId { get; set; }
        [Required, Integer]
        public long ReceiverId { get; set; }

        [Required]
        public string MediaPath { get; set; } = string.Empty;
    }
}
