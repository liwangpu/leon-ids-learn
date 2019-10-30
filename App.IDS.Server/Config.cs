using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace App.IDS.Server
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> GetApis()
        {
            var apis = new List<ApiResource>();

            //apis.Add(new ApiResource("orderApi", "orderApi"));
            apis.Add(new ApiResource("userApi", "userApi"));

            apis.Add(new ApiResource("orderApi", "orderApi") { ApiSecrets = { new Secret("123456".Sha256()) } });
            //apis.Add(new ApiResource("userApi", "userApi") { ApiSecrets = { new Secret("654321".Sha256()) } });

            return apis;
        }

        public static IEnumerable<Client> GetClients()
        {
            var clients = new List<Client>();
            var inteapp = new Client
            {
                ClientId = "inteapp",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "orderApi", "userApi" }
            };
            var orderapp = new Client
            {
                ClientId = "orderapp",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "orderApi" },
                AccessTokenType = AccessTokenType.Reference
            };
            var userapp = new Client
            {
                ClientId = "userapp",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "userApi" }
            };
            clients.Add(inteapp);
            clients.Add(orderapp);
            clients.Add(userapp);
            return clients;
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
                 {
                                 new TestUser
                                 {
                                      SubjectId="1",
                                      Username="admin",
                                      Password="123456",
                                      Claims=new List<Claim>
                                      {
                                        new Claim("justtest","xixi")
                                      }
                                 }
                  };
        }

    }
}
