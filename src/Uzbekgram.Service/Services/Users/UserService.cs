using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.DataAccess.Interfaces;
using Uzbekgram.Domain.Entities.Users;
using Uzbekgram.Domain.Exceptions;
using Uzbekgram.Service.Dtos.Users;
using Uzbekgram.Service.Interfaces;
using Uzbekgram.Service.Interfaces.Users;

namespace Uzbekgram.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public UserService(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }
        public async Task<bool> UpdateAsync(long id, UserUpdateDto userUpdateDto)
        {
            var res = await _unitOfWork.Users.FindByIdAsync(id);

            if (res is not null) 
            {
                _unitOfWork.Entry(res).State = EntityState.Detached;
                User user = (User)userUpdateDto;

                if (userUpdateDto.Fullname is not null)
                {
                    user.Fullname = userUpdateDto.Fullname;
                }
                else
                {
                    user.Fullname = res.Fullname;
                }

                if (userUpdateDto.Bio is not null)
                {
                    user.Bio = userUpdateDto.Bio;
                }
                else
                {
                    user.Bio = res.Bio;
                }

                if (userUpdateDto.Username is not null)
                {
                    user.Username = userUpdateDto.Username;
                }
                else
                {
                    user.Username = res.Username;
                }

                if (userUpdateDto.Image is not null)
                {
                    user.ImagePath = await _fileService.SaveImageAsync(userUpdateDto.Image);
                }
                else
                {
                    user.ImagePath = res.ImagePath;
                }

                _unitOfWork.Users.Update(id, user);
                var result = await _unitOfWork.SaveChangesAsync();
                return result > 0;
            }
            else { throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!"); }
        }
    }
}
