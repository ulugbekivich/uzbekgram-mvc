using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Service.Dtos.Contacts;

namespace Uzbekgram.Service.Interfaces.Contacts
{
    public interface IContactService
    {
        public Task<bool> CreateAsync(CreateContactDto createContactDto);
    }
}
