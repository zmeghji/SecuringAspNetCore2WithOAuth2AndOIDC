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
        public static IEnumerable<ApiResource> GetApiResources()
        {
            var apiResources = new List<ApiResource>();
            apiResources.Add(
                new ApiResource("imagegalleryapi", "Image Gallery API", new List<string> { "role" })
                );
            return apiResources;
        }
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
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "imagegalleryapi"
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
            identityResources.Add(new IdentityResources.Address());
            identityResources.Add(new IdentityResource("roles", "Your role(s)",new List<string> { "role" }));

            return identityResources;
        }
        public static List<TestUser> GetUsers()
        {
            var users = new List<TestUser>();
            users.Add(
                new TestUser
                {
                    SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    Username = "Frank",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Frank"),
                        new Claim("family_name", "Underwood"),
                        new Claim("address", "Main Road 1"),
                        new Claim("role", "FreeUser")
                    }
                }
                );
            users.Add(
                new TestUser
                {
                    SubjectId = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                    Username = "Claire",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Claire"),
                        new Claim("family_name", "Underwood"),
                        new Claim("address", "Big Street 2"),
                        new Claim("role", "PayingUser")

                    }
                }
                );
            return users;
        }
    }
}
