//using HospitalManagementSystem.Models.Auth;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using System.Net.Mail;
//using System.Net;
//using HospitalManagementSystem.Dto.Auth;

//namespace HospitalManagementSystem.Services.Repos
//{
//    public class EmailRepo : IEmailSender<SignUpRequestDto>
//    {
//        public Task SendConfirmationLinkAsync(SignUpRequestDto user, string email, string confirmationLink)
//        {
//            var smtpClient = new SmtpClient(Environment.GetEnvironmentVariable("SMTP_HOST"))
//            {
//                Port = 587,
//                Credentials = new NetworkCredential(Environment.GetEnvironmentVariable("SMTP_USERNAME"), Environment.GetEnvironmentVariable("SMTP_PASSWORD")),
//                EnableSsl = true,
//            };

//            var mailMessage = new MailMessage
//            {
//                From = new MailAddress("no-reply@agrimarket.com"),
//                Subject = "Your Confirmation email",
//                Body = $"<p>Dear {user.FirstName},</p><p>Please confirm your email address by clicking the following link:</p><p><a href='{confirmationLink}'>Confirm Email</a></p>",
//                IsBodyHtml = true,
//            };
//            mailMessage.To.Add(email);

//            return smtpClient.SendMailAsync(mailMessage);
//        }

//        public Task SendPasswordResetCodeAsync(SignUpRequestDto user, string email, string resetCode)
//        {
//            throw new NotImplementedException();
//        }

//        public Task SendPasswordResetLinkAsync(SignUpRequestDto user, string email, string resetLink)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
