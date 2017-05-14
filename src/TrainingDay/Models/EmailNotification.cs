using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Threading.Tasks;

namespace TrainingDay.Models
{   
    public class EmailNotification
    {
        //sends email via gmail, accepts email address of recepient as argument
        internal static void SendEmail(string recepient) 
        {   //create message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TrainingDay", "trainingdaytesting@gmail.com"));
            message.To.Add(new MailboxAddress(recepient));
            message.Subject =" Training Day Feedback";

            message.Body = new TextPart("plain")
            {
                Text = @"You have new feedback to review in TrainingDay"
            };

            //email client info/authentication
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("trainingdaytesting@gmail.com", "Testing#1");
                client.Send(message);
                client.Disconnect(true);
                
            }
        }
        
    }
 }

