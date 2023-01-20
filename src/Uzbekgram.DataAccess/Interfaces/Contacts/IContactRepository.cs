using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Entities.Contacts;

namespace Uzbekgram.DataAccess.Interfaces.Contacts
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
    }
}
