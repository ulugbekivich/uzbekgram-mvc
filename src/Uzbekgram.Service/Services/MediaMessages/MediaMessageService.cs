using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.DataAccess.Interfaces;
using Uzbekgram.Domain.Entities.Messages;
using Uzbekgram.Domain.Exceptions;
using Uzbekgram.Service.Dtos.MediaMessages;
using Uzbekgram.Service.Dtos.TextMessages;
using Uzbekgram.Service.Interfaces;
using Uzbekgram.Service.Interfaces.MediaMessages;

namespace Uzbekgram.Service.Services.MediaMessages
{
    public class MediaMessageService : IMediaMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public MediaMessageService(IUnitOfWork unitOfWork,
                                   IFileService fileService)
        {
            this._unitOfWork = unitOfWork;
            this._fileService = fileService;
        }
        public async Task<bool> CreateMediaAsync(CreateMediaMessageDto createMediaMessageDto)
        {
            var senderId = await _unitOfWork.Users.FindByIdAsync(createMediaMessageDto.SenderId);
            if (senderId is null) { throw new StatusCodeException(HttpStatusCode.NotFound, "Sender user not found"); }

            var receiverId = await _unitOfWork.Users.FindByIdAsync(createMediaMessageDto.ReceiverId);
            if (senderId is null) { throw new StatusCodeException(HttpStatusCode.NotFound, "Receiver user not found"); }

            MediaMessage media = (MediaMessage)createMediaMessageDto;

            if (createMediaMessageDto.Media is not null)
            {
                media.MediaPath = await _fileService.SaveImageAsync(createMediaMessageDto.Media);
            }

            _unitOfWork.MediaMessages.Add(media);
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }
    }
}
