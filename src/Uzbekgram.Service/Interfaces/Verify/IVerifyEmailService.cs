using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Service.Dtos.Verify;

namespace Uzbekgram.Service.Interfaces.Verify
{
    public interface IVerifyEmailService
    {
        Task<bool> SendCodeAsync(SendCodeToEmailDto sendCodeToEmailDto);

        Task<bool> VerifyEmail(VerifyEmailDto verifyEmailDto);

        Task<bool> VerifyPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}
