using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Service.Dtos.MediaMessages;
using Uzbekgram.Service.Dtos.TextMessages;

namespace Uzbekgram.Service.Interfaces.MediaMessages
{
    public interface IMediaMessageService
    {
        public Task<bool> CreateMediaAsync(CreateMediaMessageDto createMediaMessageDto);
    }
}
