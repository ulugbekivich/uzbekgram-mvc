using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.DataAccess.Interfaces;
using Uzbekgram.Domain.Entities.Users;
using Uzbekgram.Domain.Exceptions;
using Uzbekgram.Service.Dtos.Accounts;
using Uzbekgram.Service.Interfaces;
using Uzbekgram.Service.Interfaces.Accounts;
using Uzbekgram.Service.Security;

namespace Uzbekgram.Service.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IAuthManager _authManager;

        public AccountService(IUnitOfWork unitOfWork,
                              IFileService fileService,
                              IAuthManager authManager)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _authManager = authManager;
        }
        public async Task<string> AccountloginAsync(AccountLoginDto accountLoginDto)
        {
            var res = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.Email == accountLoginDto.Email);
            if (res == null) { throw new StatusCodeException(HttpStatusCode.NotFound, "User not found, Email is incorrect!"); }

            if (PasswordHasher.Verify(accountLoginDto.Password, res.Salt, res.PasswordHash))
                return _authManager.GenerateToken(res);

            throw new StatusCodeException(HttpStatusCode.BadRequest, message: "Password is wrong");
        }

        public async Task<bool> AccountRegisterAsync(AccountRegisterDto accountRegisterDto)
        {
            var res = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.Email == accountRegisterDto.Email);
            if (res is not null)
                throw new StatusCodeException(HttpStatusCode.Conflict, "Email is already exist");

            User user = (User)accountRegisterDto;

            if (accountRegisterDto.Image is not null)
            {
                user.ImagePath = await _fileService.SaveImageAsync(accountRegisterDto.Image);
            }

            var hashResult = PasswordHasher.Hash(accountRegisterDto.Password);

            user.Salt = hashResult.Salt;

            user.PasswordHash = hashResult.Hash;

            _unitOfWork.Users.Add(user);
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }
    }
}
