﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){ Scopes = {"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceReadCatalog"){Scopes = {"CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes = {"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes = {"OrderFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes = {"BasketFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes = {"CargoPullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Read authority for catalog opeations"),
            new ApiScope("DiscountFullPermission","Full authority for Discount operations" ),
            new ApiScope("OrderFullPermission","Full authority for Order operations"),
            new ApiScope("CargoPullPermission","Full authority for Cargo Operations"),
            new ApiScope("BasketFullPermission","Full authority for Basket Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //visitor
            new Client
            {
                ClientId  ="MultishopVisitorID",
                ClientName = "Multi Shop Visitor User",
                AllowedGrantTypes = {GrantType.ClientCredentials },
                ClientSecrets = {new Secret("multishopsecret".ToSha256())},
                AllowedScopes = {"CatalogReadPermission"}
            },
            //Manager
            new Client
            {
                ClientId = "MultiShopManagerID",
                ClientName = "Multi Shop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission" }
            },

            //Admin
            new Client
            {
                ClientId = "MultishopAdminID",
                ClientName = "Multi Shop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha512())},
                AllowedScopes = { "CatalogFullPermission" , "CatalogReadPermission" , "DiscountFullPermission", "OrderFullPermission"
                , "CargoPullPermission","BasketFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                }
                ,AccessTokenLifetime = 600
            }
        };
    }
}