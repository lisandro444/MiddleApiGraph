using ApiGraph.Entities;
using Microsoft.ApplicationInsights;
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiGraph.Controllers
{
    public class GraphIntegrationController : ApiController
    {
        private TelemetryClient telemetryClient = new TelemetryClient();

        [HttpPost]
        [Route("api/Integration/SendMail")]
        public async Task<IHttpActionResult> SendMail([FromBody] MailParameters parameters)
        {
            try
            {
                telemetryClient.TrackTrace("Sending Email....");

                var clientId = "3d05fbdd-713c-40d7-be36-3b2a7344d860";
                var tenantId = "629fd4e8-9d26-4da5-85ff-cc01ca1948c4";
                var clientSecret = "C-vI8s0VlB1TCTY~lq39y1dg5Q~tZ9kxX.";


                IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                    .Create(clientId)
                    .WithTenantId(tenantId)
                    .WithClientSecret(clientSecret)
                    .Build();

                ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);
                GraphServiceClient graphClient = new GraphServiceClient(authProvider);
     
                    var message = new Message
                    {
                        Subject = parameters.subject,
                        Body = new ItemBody
                        {
                            ContentType = BodyType.Html,
                            Content = "<h5>This email was sent from middle API</h5>"
                        },
                        ToRecipients = new List<Recipient>()
                        {
                            new Recipient
                            {
                                EmailAddress = new EmailAddress
                                {
                                    Address = parameters.mailTo
                                }
                            },
                             new Recipient
                            {
                                EmailAddress = new EmailAddress
                                {
                                    Address = "c_lrossi@medicalcardsystem.com"
                                }
                            },
                             new Recipient
                            {
                                EmailAddress = new EmailAddress
                                {
                                    Address = "admin@lisandrorossi444.onmicrosoft.com"
                                }
                            }

                        }
                    };

                    var saveToSentItems = false;

                    await graphClient.Users["admin@lisandrorossi444.onmicrosoft.com"]
                            .SendMail(message, saveToSentItems)
                            .Request()
                            .PostAsync();

                telemetryClient.TrackTrace("The email was sent correcly to: " + message.ToRecipients.FirstOrDefault().EmailAddress.Address);

                return Ok("Connection with Graph was Successfully, El subject del mail es: " + subject);
            }
            catch (Exception e)
            {
                telemetryClient.TrackTrace("Sending Email Exception:" + e.Message);
                return Ok("Error Message:" + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}