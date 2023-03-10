using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uzbekgram.Service.Dtos.Verify;

namespace Uzbekgram.Service.Interfaces.Verify
{
    public interface IEmailService
    {
        public Task SendAsync(EmailMessageDto emailMessageDto);

        Task VerifyPasswordAsync(ResetPasswordDto password);
    }
}
