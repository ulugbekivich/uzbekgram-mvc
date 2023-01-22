using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Service.Dtos.Users;

namespace Uzbekgram.Service.Interfaces.Users
{
    public interface IUserService
    {
        public Task<bool> UpdateAsync(long id, UserUpdateDto userUpdateDto);
    }
}
