using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.DataAccess.DbContexts;
using Uzbekgram.DataAccess.Interfaces.Messages;
using Uzbekgram.Domain.Entities.Messages;

namespace Uzbekgram.DataAccess.Repositories.Messages
{
    public class TextMessageRepository : GenericRepository<TextMessage>, ITextMessageRepository
    {
        public TextMessageRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
