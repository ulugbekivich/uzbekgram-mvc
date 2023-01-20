using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.DataAccess.Interfaces.Contacts;
using Uzbekgram.DataAccess.Interfaces.Messages;
using Uzbekgram.DataAccess.Interfaces.Users;

namespace Uzbekgram.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }

        public ITextMessageRepository TextMessages { get; }
        public IMediaMessageRepository MediaMessages { get; }

        public IContactRepository Contacts { get; }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        public Task<int> SaveChangesAsync();
    }
}
