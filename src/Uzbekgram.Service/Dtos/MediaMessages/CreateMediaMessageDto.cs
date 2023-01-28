using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Entities.Messages;
using Uzbekgram.Domain.Entities.Users;
using Uzbekgram.Service.Common.Attributes;

namespace Uzbekgram.Service.Dtos.MediaMessages
{
    public class CreateMediaMessageDto
    {
        [Required, Integer]
        public long SenderId { get; set; }
        [Required, Integer]
        public long ReceiverId { get; set; }

        [Required, MaxFileSize(2), AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp",
                                                               ".webm", ".mkv", ".vob", ".gif", ".avi", ".mp4", ".m4p"})]
        public IFormFile? Media { get; set; }

        public static implicit operator MediaMessage(CreateMediaMessageDto dto)
        {
            return new MediaMessage()
            {
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId
            };
        }
    }
}
