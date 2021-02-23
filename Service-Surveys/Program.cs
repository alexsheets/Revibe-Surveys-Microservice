using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Surveys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            // creating Amazon SES in main...
            using (var client = new AmazonSimpleEmailServiceClient(Amazon.RegionEndpoint.USEast1))
            {
                var req = new SendEmailRequest
                {
                    Source = "noreply@revibe.tech",
                    // dev@revibe.tech
                    Destination = new Destination { ToAddresses = {"srevibe@gmail.com"} },
                    Message = new Message
                    {
                        Subject = new Content("Revibe received a new contact submission!"),
                        Body = new Body
                        {
                            Html = new Content("<html><body><h2>The email worked!</h2></body></html>")
                        }
                    }
                };
                try
                {
                    var response = client.SendEmailAsync(req).Result;
                    Console.WriteLine("Email sent! Message ID = {0}", response.MessageId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Send failed with exception: {0}", ex.Message);
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
