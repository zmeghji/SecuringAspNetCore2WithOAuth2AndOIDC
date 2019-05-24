using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Marvin.IDP
{
    public static class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            var clients = new List<Client>();
            clients.Add(
                new Client
                {
                    ClientName = "Image Gallery",
                    ClientId = "imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44317/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44317/signout-callback-oidc"
                    },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    ClientSecrets = { new Secret("secret".Sha256()) }
                }
                );
            return clients;
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var identityResources = new List<IdentityResource>();
            identityResources.Add(new IdentityResources.OpenId());
            identityResources.Add(new IdentityResources.Profile());

            return identityResources;
        }
        public static List<TestUser> GetUsers()
        {
            var users = new List<TestUser>();
            users.Add(
                new TestUser
                {
                    SubjectId = "752e598f-6007-4099-9164-5d07dc7bdaf5",
                    Username = "Frank",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Frank"),
                        new Claim("family_name", "Underwood")
                    }
                }
                );
            users.Add(
                new TestUser
                {
                    SubjectId = "1fdca2e7-d000-4c23-b580-b553158ef20f",
                    Username = "Claire",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Claire"),
                        new Claim("family_name", "Underwood")
                    }
                }
                );
            return users;
        }
    }
}
