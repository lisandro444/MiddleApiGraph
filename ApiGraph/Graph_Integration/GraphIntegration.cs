using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGraph.Graph_Integration
{
    public class GraphIntegration
    {
        public void SendMail(string subject, List<string> receptores, string body)
        {
    //        var message = new Message
    //        {
    //            Subject = "Testing Microsfot Graph",
    //            Body = new ItemBody
    //            {
    //                ContentType = BodyType.Html,
    //                Content = "<h3>Test works</h3>"
    //            },
    //            ToRecipients = new List<Recipient>()
    //{
    //    new Recipient
    //    {
    //        EmailAddress = new EmailAddress
    //        {
    //            Address = "lisandrorossi444@gmail.com"
    //        }
    //    }
    //},
    //            CcRecipients = new List<Recipient>()
    //{
    //    new Recipient
    //    {
    //        EmailAddress = new EmailAddress
    //        {
    //            Address = "admin@lisandrorossi444.onmicrosoft.com"
    //        }
    //    }
    //}
    //        };

    //        var saveToSentItems = false;

    //        await graphClient.Users["admin@lisandrorossi444.onmicrosoft.com"]
    //                .SendMail(message, saveToSentItems)
    //                .Request()
    //                .PostAsync();


        }
    }
}