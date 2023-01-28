using Microsoft.Extensions.Configuration;
using System.Net;
using Uzbekgram.DataAccess.DbContexts;
using Uzbekgram.Service.Dtos.Verify;
using Uzbekgram.Service.Interfaces.Verify;
using Uzbekgram.Service.Security;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;
using Uzbekgram.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Uzbekgram.Service.Services.Verify
{
    public class EmailService : IEmailService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public EmailService(IConfiguration configuration, AppDbContext appDbContext)
        {
            _context = appDbContext;
            _config = configuration.GetSection("Email");
        }

        public async Task SendAsync(EmailMessageDto emailMessage)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_config["Email"]));
            email.To.Add(MailboxAddress.Parse(emailMessage.To));
            email.Subject = emailMessage.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailMessage.Body.ToString() };

            var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["Host"], 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_config["Email"], _config["Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task VerifyPasswordAsync(ResetPasswordDto password)
        {
            var admin = await _context.Users.FirstOrDefaultAsync(p => p.Email == password.Email);

            if (admin is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, message: "user not found!");

            var changedPassword = PasswordHasher.ChangePassword(password.Password, admin.Salt);

            admin.PasswordHash = changedPassword;

            _context.Users.Update(admin);

            await _context.SaveChangesAsync();
        }
    }
}
