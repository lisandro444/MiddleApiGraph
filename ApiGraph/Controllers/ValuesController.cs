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
    public class ValuesController : ApiController
    {
        //private TelemetryClient telemetryClient = new TelemetryClient();
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //[HttpPost]
        //[Route("api/Integration/SendMail")]
        //public async Task<IHttpActionResult> SendMail(string subject)
        //{
        //    try
        //    {
        //        telemetryClient.TrackTrace("Sending Email....");

        //        var clientId = "3d05fbdd-713c-40d7-be36-3b2a7344d860";
        //        var tenantId = "629fd4e8-9d26-4da5-85ff-cc01ca1948c4";
        //        var clientSecret = "C-vI8s0VlB1TCTY~lq39y1dg5Q~tZ9kxX.";


        //        IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
        //            .Create(clientId)
        //            .WithTenantId(tenantId)
        //            .WithClientSecret(clientSecret)
        //            .Build();

        //        ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);
        //        GraphServiceClient graphClient = new GraphServiceClient(authProvider);

        //        var groups = await graphClient.Groups.Request().Select(x => new { x.Id, x.DisplayName }).GetAsync();

        //        return Ok("Connection with Graph was Successfully: " + groups.FirstOrDefault().Id + "El subject del mail es: " + subject);
        //    }
        //    catch (Exception e)
        //    {
        //        telemetryClient.TrackTrace("Sending Email Exception:" +e.Message);
        //        return Ok("Error Message:" + e.Message + "\n" + e.StackTrace);
        //    }
        //}

    }
}
