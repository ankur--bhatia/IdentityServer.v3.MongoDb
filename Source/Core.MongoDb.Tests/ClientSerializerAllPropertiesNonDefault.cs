﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using IdentityServer.Core.MongoDb;
using MongoDB.Bson;
using Thinktecture.IdentityServer.Core.Models;
using Xunit;

namespace Core.MongoDb.Tests
{
    public class ClientSerializerAllPropertiesNonDefault
    {
        private readonly Client _expected;
        private readonly Client _actual;

        public ClientSerializerAllPropertiesNonDefault()
        {
            _expected = new Client
            {
                AbsoluteRefreshTokenLifetime = 10,
                AccessTokenLifetime = 20,
                AccessTokenType = AccessTokenType.Reference,
                AllowLocalLogin = false,
                AllowRememberConsent = true,
                AuthorizationCodeLifetime = 30,
                ClientId = "123",
                ClientName = "TEST",
                ClientSecret = "secret",
                ClientUri = "clientUri",
                Enabled = true,
                Flow = Flows.AuthorizationCode,
                IdentityProviderRestrictions = new[] { "idpr" },
                IdentityTokenLifetime = 40,
                IdentityTokenSigningKeyType = SigningKeyTypes.ClientSecret,
                LogoUri = new Uri("uri:logo"),
                PostLogoutRedirectUris = { new Uri("uri:logout") },
                RedirectUris = { new Uri("uri:redirect") },
                RefreshTokenExpiration = TokenExpiration.Sliding,
                RefreshTokenUsage = TokenUsage.ReUse,
                RequireConsent = true,
                ScopeRestrictions = { "restriction" },
                SlidingRefreshTokenLifetime = 50
            };
            var serializer = new ClientSerializer();
            var doc = serializer.Serialize(_expected);
            
            _actual = serializer.Deserialize(doc);

        }

        [Fact]
        public void CheckDeserializedShouldNotBeNull()
        {
            Assert.NotNull(_actual);
        }

        [Fact]
        public void CheckAbsoluteRefreshTokenLifetime()
        {
            Assert.Equal(_expected.AbsoluteRefreshTokenLifetime, _actual.AbsoluteRefreshTokenLifetime);
        }

        [Fact]
        public void CheckAccessTokenLifetime()
        {
            Assert.Equal(_expected.AccessTokenLifetime, _actual.AccessTokenLifetime);
        }
        [Fact]
        public void CheckAccessTokenType()
        {
            Assert.Equal(_expected.AccessTokenType, _actual.AccessTokenType);
        }
        [Fact]
        public void CheckAllowLocalLogin()
        {
            Assert.Equal(_expected.AllowLocalLogin, _actual.AllowLocalLogin);
        }
        [Fact]
        public void CheckAllowRememberConsent()
        {
            Assert.Equal(_expected.AllowRememberConsent, _actual.AllowRememberConsent);
        }
        [Fact]
        public void CheckAuthorizationCodeLifetime()
        {
            Assert.Equal(_expected.AuthorizationCodeLifetime, _actual.AuthorizationCodeLifetime);
        }
        [Fact]
        public void CheckClientId()
        {
            Assert.Equal(_expected.ClientId, _actual.ClientId);
        }
        [Fact]
        public void CheckClientName()
        {
            Assert.Equal(_expected.ClientName, _actual.ClientName);
        }
        [Fact]
        public void CheckClientSecret()
        {
            Assert.Equal(_expected.ClientSecret, _actual.ClientSecret);
        }
        [Fact]
        public void CheckClientUri()
        {
            Assert.Equal(_expected.ClientUri, _actual.ClientUri);
        }
        [Fact]
        public void CheckEnabled()
        {
            Assert.Equal(_expected.Enabled, _actual.Enabled);
        }
        [Fact]
        public void CheckFlow()
        {
            Assert.Equal(_expected.Flow, _actual.Flow);
        }
        [Fact]
        public void CheckIdentityProviderRestrictions()
        {
            Assert.Equal(_expected.IdentityProviderRestrictions, _actual.IdentityProviderRestrictions);
        }
        [Fact]
        public void CheckIdentityTokenLifetime()
        {
            Assert.Equal(_expected.IdentityTokenLifetime, _actual.IdentityTokenLifetime);
        }
        [Fact]
        public void CheckIdentityTokenSigningKeyType()
        {
            Assert.Equal(_expected.IdentityTokenSigningKeyType, _actual.IdentityTokenSigningKeyType);
        }
        [Fact]
        public void CheckLogoUri()
        {
            Assert.Equal(_expected.LogoUri, _actual.LogoUri);
        }
        [Fact]
        public void CheckPostLogoutRedirectUris()
        {
            Assert.Equal(_expected.PostLogoutRedirectUris, _actual.PostLogoutRedirectUris);
        }
        [Fact]
        public void CheckRedirectUris()
        {
            Assert.Equal(_expected.RedirectUris, _actual.RedirectUris);
        }
        [Fact]
        public void CheckRefreshTokenExpiration()
        {
            Assert.Equal(_expected.RefreshTokenExpiration, _actual.RefreshTokenExpiration);
        }
        [Fact]
        public void CheckRefreshTokenUsage()
        {
            Assert.Equal(_expected.RefreshTokenUsage, _actual.RefreshTokenUsage);
        }
        [Fact]
        public void CheckRequireConsent()
        {
            Assert.Equal(_expected.RequireConsent, _actual.RequireConsent);
        }
        [Fact]
        public void CheckScopeRestrictions()
        {
            Assert.Equal(_expected.ScopeRestrictions, _actual.ScopeRestrictions);
        }
        [Fact]
        public void CheckSlidingRefreshTokenLifetime()
        {
            Assert.Equal(_expected.SlidingRefreshTokenLifetime, _actual.SlidingRefreshTokenLifetime);
        }
        
    }
}