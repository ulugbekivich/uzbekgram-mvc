using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.DataAccess.DbContexts;
using Uzbekgram.DataAccess.Interfaces;
using Uzbekgram.DataAccess.Interfaces.Contacts;
using Uzbekgram.DataAccess.Interfaces.Messages;
using Uzbekgram.DataAccess.Interfaces.Users;
using Uzbekgram.DataAccess.Repositories.Contacts;
using Uzbekgram.DataAccess.Repositories.Messages;
using Uzbekgram.DataAccess.Repositories.Users;

namespace Uzbekgram.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public IUserRepository Users { get; }

        public ITextMessageRepository TextMessages { get; }

        public IMediaMessageRepository MediaMessages { get; }

        public IContactRepository Contacts { get; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
            Users = new UserRepository(appDbContext);
            TextMessages = new TextMessageRepository(appDbContext);
            MediaMessages= new MediaMessageRepository(appDbContext);
            Contacts = new ContactRepository(appDbContext);
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return dbContext.Entry(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
