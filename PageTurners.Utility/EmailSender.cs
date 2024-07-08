using System;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PageTurners.Utility
{
	public class EmailSender : IEmailSender
	{

        public string SendGridSecret { get; set; }

        public EmailSender(IConfiguration _config)
        {
           SendGridSecret = Environment.GetEnvironmentVariable("SENDGRID_SECRET_KEY");
           
        }

        //public Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //    //logic to send email

        //    var client = new SendGridClient(SendGridSecret);

        //    var from = new EmailAddress("rokesh.prakash@stonybrook.edu", "Page Turner");
        //    var to = new EmailAddress(email);
        //    var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

        //    return client.SendEmailAsync(message);





        //}

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var client = new SendGridClient(SendGridSecret);
                var from = new EmailAddress("rokesh.prakash@stonybrook.edu", "Page Turner");
                var to = new EmailAddress(email);
                var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

                var response = await client.SendEmailAsync(message);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    // Log the error response
                    Console.WriteLine($"Failed to send email: {response.StatusCode}");
                    Console.WriteLine(await response.Body.ReadAsStringAsync());
                }
                else
                {
                    Console.WriteLine("Email sent successfully");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }


    }
}

