using UpStorage.Domain.Common.Models.Email;

namespace UpStorage.Domain.Common.Interfaces
{
    public interface IEmailService
    {
        void SendEmailConfirmation(SendEmailConfirmationDto sendEmailConfirmationDto);
    }
}
