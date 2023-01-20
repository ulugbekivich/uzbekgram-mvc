using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Domain.Entities.Users;

namespace Uzbekgram.DataAccess.Interfaces.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
