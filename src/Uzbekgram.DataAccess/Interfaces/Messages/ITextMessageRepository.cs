using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Entities.Messages;

namespace Uzbekgram.DataAccess.Interfaces.Messages
{
    public interface ITextMessageRepository : IGenericRepository<TextMessage>
    {
    }
}
