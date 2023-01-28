using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Service.Dtos.Accounts;
using Uzbekgram.Service.Dtos.TextMessages;

namespace Uzbekgram.Service.Interfaces.TextMessages
{
    public interface ITextMessageService
    {
        public Task<bool> CreateMessageAsync(CreateTextMessageDto createTextMessageDto);
    }
}
