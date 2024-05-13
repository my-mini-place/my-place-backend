using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExternalInterfaces
{
    public interface IEmailSender
    {
        Task<Result> SendEmailAsync(string email, string subject, string message);
    }
}