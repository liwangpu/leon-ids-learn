using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace App.IDS.Server
{
    public static class IdentityConfig
    {
        public static IEnumerable<IdentityResource> GetIds()
        {
            var ids = new IdentityResource[]
                {
                        new IdentityResources.OpenId()
                };

            return ids;
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            var apis = new List<ApiResource>();

            //apis.Add(new ApiResource("omsApi", "omsApi"));
            //apis.Add(new ApiResource("smsApi", "smsApi"));

            apis.Add(new ApiResource("omsApi", "omsApi") { ApiSecrets = { new Secret("123456".Sha256()) } });
            apis.Add(new ApiResource("smsApi", "smsApi") { ApiSecrets = { new Secret("654321".Sha256()) } });
            apis.Add(new ApiResource("testApi", "testApi")
            {
                UserClaims = new[] { "aa" }
            });
            apis.Add(new ApiResource("ocelotApi", "ocelotApi")
            {
                ApiSecrets = { new Secret("88888888".Sha256()) },
                //UserClaims = new[] { "user.action" }
            });
            return apis;
        }

        public static IEnumerable<Client> GetClients()
        {
            var clients = new List<Client>();
            var ocelotapp = new Client
            {
                ClientId = "ocelotapp",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("secret".Sha256()) },
                RequireClientSecret = false,
                AllowedScopes = { "omsApi", "ocelotApi" },
                AccessTokenType = AccessTokenType.Reference
            };
            var omsapp = new Client
            {
                ClientId = "omsapp",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "omsApi" },
                AccessTokenType = AccessTokenType.Reference
            };
            var smsapp = new Client
            {
                ClientId = "smsapp",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "smsApi" },
                AccessTokenType = AccessTokenType.Reference
            };
            var testapp = new Client
            {
                ClientId = "testapp",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "testApi" },
                RequireClientSecret = false,
                Claims = new[] { new Claim("aa", "1") },
                AccessTokenType = AccessTokenType.Jwt
            };
            clients.Add(ocelotapp);
            //clients.Add(omsapp);
            //clients.Add(smsapp);
            //clients.Add(testapp);
            return clients;
        }

        public static List<TestUser> GetUsers()
        {
            var users = new List<TestUser>();

            users.Add(new TestUser
            {
                SubjectId = "1",
                Username = "admin",
                Password = "123456",
                Claims = new List<Claim>
                                {
                                    new Claim("justtest","xixi")
                                 }
            });
            return users;
        }
    }
}
