using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Entities.Messages;
using Uzbekgram.Domain.Entities.Users;
using Uzbekgram.Service.Common.Attributes;

namespace Uzbekgram.Service.Dtos.TextMessages
{
    public class CreateTextMessageDto
    {
        [Required, Integer]
        public long SenderId { get; set; }
        [Required, Integer]
        public long ReceiverId { get; set; }
        [Required]
        public string Message { get; set; } = string.Empty;

        public static implicit operator TextMessage(CreateTextMessageDto dto)
        {
            return new TextMessage()
            {
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
                Message = dto.Message,
            };
        }
    }
}
