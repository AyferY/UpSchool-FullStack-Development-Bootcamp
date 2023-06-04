namespace UpStorage.Domain.Common.Models.Email
{
    public class SendEmailDto
    {
        public List<String> EmailAddresses { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public SendEmailDto(List<String> emailAddresses, string subject, string content)
        {
            EmailAddresses = emailAddresses;
            Subject = subject;
            Content = content;
        }

        public SendEmailDto(string emailAddresses, string subject, string content)
        {
            EmailAddresses = new List<string>() { emailAddresses };
            Subject = subject;
            Content = content;
        }
    }
}
