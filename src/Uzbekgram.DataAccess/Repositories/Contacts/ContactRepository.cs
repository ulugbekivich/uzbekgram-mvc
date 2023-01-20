using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.DataAccess.DbContexts;
using Uzbekgram.DataAccess.Interfaces.Contacts;
using Uzbekgram.Domain.Entities.Contacts;

namespace Uzbekgram.DataAccess.Repositories.Contacts
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
