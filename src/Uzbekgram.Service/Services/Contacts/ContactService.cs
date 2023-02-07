using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.DataAccess.Interfaces;
using Uzbekgram.DataAccess.Repositories;
using Uzbekgram.Domain.Entities.Contacts;
using Uzbekgram.Domain.Exceptions;
using Uzbekgram.Service.Dtos.Contacts;
using Uzbekgram.Service.Dtos.MediaMessages;
using Uzbekgram.Service.Interfaces.Common;
using Uzbekgram.Service.Interfaces.Contacts;
using Uzbekgram.Service.Services.Common;

namespace Uzbekgram.Service.Services.Contacts
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityService _identityService;

        public ContactService(IUnitOfWork unitOfWork,
                              IIdentityService identityService)
        {
            _unitOfWork = unitOfWork;
            _identityService = identityService;
        }
        public async Task<bool> CreateAsync(CreateContactDto createContactDto)
        {
            var userId = await _unitOfWork.Users.FindByIdAsync(_identityService.Id!.Value);
            if (userId is null) { throw new StatusCodeException(HttpStatusCode.NotFound, "User not found"); }

            var friendId = await _unitOfWork.Users.FindByIdAsync(createContactDto.FriendId);
            if (friendId is null) { throw new StatusCodeException(HttpStatusCode.NotFound, "Friend user not found"); }

            Contact contact = (Contact)createContactDto;

            contact.UserId = _identityService.Id!.Value;

            _unitOfWork.Contacts.Add(contact);
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }
    }
}
