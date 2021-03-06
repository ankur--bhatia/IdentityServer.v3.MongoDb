/*
 * Copyright 2014, 2015 James Geall
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Thinktecture.IdentityServer.Core.Models;
using Thinktecture.IdentityServer.Core.Services;
using Xunit;

namespace Core.MongoDb.Tests
{
    public class ClientSerializerOnlyMandatoryPropertiesSet : PersistenceTest, IUseFixture<PersistenceTestFixture>
    {
        private Client _expected;
        private Client _actual;

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
            Assert.Equal(_expected.EnableLocalLogin, _actual.EnableLocalLogin);
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
            Assert.Equal(
                _expected.ClientSecrets.Select(TestData.ToTestableString),
                _actual.ClientSecrets.Select(TestData.ToTestableString));
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

        [Fact]
        public void CheckAll()
        {
            var serializer = new JsonSerializer() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var expected = JObject.FromObject(_expected, serializer).ToString();
            var actual = JObject.FromObject(_actual, serializer).ToString();
            Assert.Equal(expected, actual);
            Console.WriteLine(actual);
        }

        protected override void Initialize()
        {
            var store = Factory.Resolve<IClientStore>();
            _expected = TestData.ClientAllProperties();
            Save(TestData.ClientAllProperties());
            _actual = store.FindClientByIdAsync(_expected.ClientId).Result;
        }
    }
}