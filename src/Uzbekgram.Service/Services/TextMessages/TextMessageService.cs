using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.DataAccess.Interfaces;
using Uzbekgram.Domain.Entities.Messages;
using Uzbekgram.Domain.Exceptions;
using Uzbekgram.Service.Dtos.TextMessages;
using Uzbekgram.Service.Interfaces.TextMessages;

namespace Uzbekgram.Service.Services.TextMessages
{
    public class TextMessageService : ITextMessageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TextMessageService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateMessageAsync(CreateTextMessageDto createTextMessageDto)
        {
            var senderId = await _unitOfWork.Users.FindByIdAsync(createTextMessageDto.SenderId);
            if(senderId is null) { throw new StatusCodeException(HttpStatusCode.NotFound, "Sender user not found"); }

            var receiverId = await _unitOfWork.Users.FindByIdAsync(createTextMessageDto.ReceiverId);
            if (senderId is null) { throw new StatusCodeException(HttpStatusCode.NotFound, "Receiver user not found"); }

            TextMessage message = (TextMessage)createTextMessageDto;

            _unitOfWork.TextMessages.Add(message);
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }
    }
}
