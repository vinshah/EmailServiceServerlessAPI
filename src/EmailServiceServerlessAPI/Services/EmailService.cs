using System;
using System.Collections.Generic;
using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using EmailServiceServerlessAPI.Models;

namespace EmailServiceServerlessAPI.Services
{
    public class EmailService
    {
        public void SendEmail(EmailEnquiryModel email)
        {
            var receiverAddress = "bhavin.shah@anbsynergies.com";

            using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.APSoutheast2))
            {
                var sendRequest = new SendEmailRequest
                {
                    Source = email.SenderEmailAddress,
                    Destination = new Destination
                    {
                        ToAddresses = new List<string> { receiverAddress }
                    },
                    Message = new Message
                    {
                        Subject = new Content(email.Subject),
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = email.Message
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = email.Message
                            }
                        }
                    },
                    // If you are not using a configuration set, comment
                    // or remove the following line 
                    //ConfigurationSetName = configSet
                };
                try
                {
                    Console.WriteLine("Sending email using Amazon SES...");
                    var response = client.SendEmailAsync(sendRequest);
                    Console.WriteLine("The email was sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The email was not sent.");
                    Console.WriteLine("Error message: " + ex.Message);

                }
            }
        }
    }
}
