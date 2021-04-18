﻿using Microsoft.Graph;
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
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/Integration/SendMail")]
        public async Task<IHttpActionResult> SendMail()
        {
            try
            {
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

                var groups = await graphClient.Groups.Request().Select(x => new { x.Id, x.DisplayName }).GetAsync();

                return Ok("Success" + groups.FirstOrDefault().DisplayName);
            }
            catch (Exception e)
            {
                return Ok("Error Message:" + e.Message + "\n" + e.StackTrace);
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
