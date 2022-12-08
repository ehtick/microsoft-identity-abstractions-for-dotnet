﻿using Microsoft.Identity.Abstractions;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class MicrosoftIdentityOptionsTests
    {
        private const string instance = "https://login.microsoftonline.com/";
        private const string clientId = "application-id-from-app-registration";
        private const string tenant = "common";
        private const string audience = clientId;
        private const string azureRegion = "westus";
        private string[] clientCapabilities = new[] { "cp1" };
        private const string domain = "mydomain.com";
        private CredentialDescription secret = new CredentialDescription { SourceType = CredentialSource.ClientSecret, ClientSecret = "blah" };
        private CredentialDescription descryptCert = new CredentialDescription { SourceType = CredentialSource.Base64Encoded, Base64EncodedValue = "0123" };
        private string[] audiences = new[] { "https://myapi", clientId };

        [Fact]
        public void MicrosoftIdentityOptionsProperties()
        {
            MicrosoftIdentityApplicationOptions microsoftIdentityApplicationOptions = new MicrosoftIdentityApplicationOptions
            {
                Instance = instance,
                TenantId = tenant,
                ClientId = clientId,
                Audience = audience,
                AzureRegion = azureRegion,
                ClientCapabilities = clientCapabilities,
                Domain = domain,
                SendX5C = true,
                WithSpaAuthCode = true,
                EnablePiiLogging = true,
                ClientCredentials = new[]
                {
                    secret
                },
                AllowWebApiToBeAuthorizedByACL = true,
                TokenDecryptionCredentials = new[]
                {
                    descryptCert
                }
            };

            Assert.Equal("https://login.microsoftonline.com/common/v2.0", microsoftIdentityApplicationOptions.Authority);
            microsoftIdentityApplicationOptions.Authority = "https://login.microsoftonline.com/common";
            Assert.Equal("https://login.microsoftonline.com/common", microsoftIdentityApplicationOptions.Authority);
            Assert.Equal(clientId, microsoftIdentityApplicationOptions.ClientId);
            Assert.Equal(tenant, microsoftIdentityApplicationOptions.TenantId);
            Assert.Equal(clientId, microsoftIdentityApplicationOptions.Audience);
            Assert.Equal(clientCapabilities, microsoftIdentityApplicationOptions.ClientCapabilities);
            Assert.Equal(azureRegion, microsoftIdentityApplicationOptions.AzureRegion);
            Assert.True(microsoftIdentityApplicationOptions.SendX5C);
            Assert.True(microsoftIdentityApplicationOptions.AllowWebApiToBeAuthorizedByACL);
            Assert.True(microsoftIdentityApplicationOptions.WithSpaAuthCode);
            Assert.True(microsoftIdentityApplicationOptions.EnablePiiLogging);
            Assert.Equal(secret, microsoftIdentityApplicationOptions.ClientCredentials.First());
            Assert.Equal(descryptCert, microsoftIdentityApplicationOptions.TokenDecryptionCredentials.First());
            Assert.Equal(domain, microsoftIdentityApplicationOptions.Domain);
        }


        [Fact]
        public void IdentityApplicationOptionsProperties()
        {
            IdentityApplicationOptions identityApplicationOptions = new IdentityApplicationOptions
            {
                Authority = "https://google.com/",
                Audiences = audiences
            };

            Assert.Equal("https://google.com/", identityApplicationOptions.Authority);
            Assert.Equal(audiences, identityApplicationOptions.Audiences);
        }
    }
}
