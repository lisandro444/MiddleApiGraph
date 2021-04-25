using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGraph.Helpers
{
    public class KeyVaultHelper
    {
        private string keyVaultEndpoint;
        private KeyVaultClient keyVaultClient;
        public string KeyVaultEndpoint { get => keyVaultEndpoint; set => keyVaultEndpoint = value; }
        public KeyVaultHelper(string endpoint)
        {
            keyVaultEndpoint = (endpoint.EndsWith("/")) ? endpoint : endpoint + "/";
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider("RunAs=Developer; DeveloperTool=AzureCli");
            keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
        }
        public string RetrieveSecret(string secretName)
        {
            var secret = keyVaultClient.GetSecretAsync($"{keyVaultEndpoint}secrets/{secretName}").ConfigureAwait(false).GetAwaiter().GetResult();
            return secret.Value;
        }
    }
}