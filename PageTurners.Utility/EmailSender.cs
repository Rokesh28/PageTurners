using System;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace PageTurners.Utility
{
	public class EmailSender : IEmailSender
	{
	
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Will implenment in Future
            return Task.CompletedTask;
        }
    }
}

