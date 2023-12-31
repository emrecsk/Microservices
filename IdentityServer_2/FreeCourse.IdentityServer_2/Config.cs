﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace FreeCourse.IdentityServer_2
{

    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("resource_catalog"){Scopes={"resource_catalog_fullpermission"} },
                new ApiResource("photo_stock"){Scopes={"photo_stock_fullpermission"} },
                new ApiResource("basket"){Scopes={"basket_fullpermission"} },
                new ApiResource("discount"){Scopes={ "discount_fullpermission" } },
                new ApiResource("order"){Scopes={ "order_fullpermission" } },
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName) //this is for identity server
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource(){Name="roles",DisplayName="Roles",Description="User Roles",UserClaims=new []{"role"} }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("resource_catalog_fullpermission","Full access for catalog api"),
                new ApiScope("photo_stock_fullpermission","Full access for photo stock api"),
                new ApiScope("basket_fullpermission","Full access for basket api"),
                new ApiScope("discount_fullpermission","Full access for discount api"),
                new ApiScope("order_fullpermission","Full access for order api"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName) //this is for identity server
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {           
                new Client
                {
                    ClientId="WebMvcClient",
                    ClientName="Asp.Net Core MVC",
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={"resource_catalog_fullpermission","photo_stock_fullpermission",IdentityServerConstants.LocalApi.ScopeName}
                },
                new Client
                {
                    ClientId="WebMvcClientForUser",
                    ClientName="Asp.Net Core MVC",
                    AllowOfflineAccess=true,
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName,
                        "roles",
                        "basket_fullpermission",
                        "discount_fullpermission",
                        "order_fullpermission"
                    },
                    AccessTokenLifetime=1*60*60,
                    RefreshTokenExpiration=TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime= (int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                    RefreshTokenUsage=TokenUsage.ReUse,
                }
            };
    }
}