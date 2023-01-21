using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Service.Dtos.Accounts;

namespace Uzbekgram.Service.Interfaces.Accounts
{
    public interface IAccountService
    {
        public Task<bool> AccountRegisterAsync(AccountRegisterDto accountRegisterDto);
        public Task<string> AccountloginAsync(AccountLoginDto accountLoginDto);
    }
}
