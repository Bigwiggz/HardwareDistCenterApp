using FluentEmail.Core;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Services.Email.Sender
{
    public class EmailSender : IEmailSender
    {
        private readonly IServiceProvider _serviceProvider;

        public EmailSender(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using (var scope=_serviceProvider.CreateScope())
            {
                var mailer = scope.ServiceProvider.GetRequiredService<IFluentEmail>();
                var emailPackage = mailer
                    .To(email, "New User")
                    .Subject(subject)
                    .Body(htmlMessage);

                await emailPackage.SendAsync();
            }
        }


    }
}
