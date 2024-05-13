using Domain;
using Microsoft.AspNetCore.Identity;
using Domain.ExternalInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Net;
using Microsoft.Extensions.Configuration;
using Domain.Errors;

namespace Infrastructure.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result> SendEmailAsync(string email, string subject, string message)
        {
            // using po to zeby sie zwolnilo
            using (var smtpClient = new SmtpClient("smtp-mail.outlook.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(_configuration["mail"], _configuration["pw"]);

                using (var mailMessage = new MailMessage(from: _configuration["mail"]!, to: email, subject, message))
                {
                    try
                    {
                        await smtpClient.SendMailAsync(mailMessage);
                        return Result.Success();
                    }
                    catch (Exception ex)
                    {
                        return Result.Failure(Error.Failure(email, $"Nie udało się wysłać emaila: {ex.Message}"));
                    }
                }
            }
        }
    }
}