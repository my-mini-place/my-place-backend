namespace Domain.ExternalInterfaces
{
    public interface IEmailSender
    {
        Task<Result> SendEmailAsync(string email, string subject, string message);
    }
}