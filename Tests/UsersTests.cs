using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Framework.Common;
using Framework.Models;
using Framework.TestData;
using NUnit.Framework;
using Serilog;

namespace Framework.Tests
{
    [TestFixture]
    public class UsersTests : TestBase
    {
        private FuturamaApiClient apiClient;
        private string url;

        [SetUp]
        protected void Initialize()
        {
            url = Config.BaseUrl;
            Log.Information("Our endpoint: " + url);
            apiClient = new FuturamaApiClient(url);
        }

        [Test]
        public async Task CreateUser()
        {
            var user = new User()
            {
                Name = "Vasya",
                Surname = "string",
                MiddleName = "string",
                Email = "vasya007@example.com",
                Username = "vasya007",
                Password = "********",
                IsSubscribed = true
            };

            var createdUser = await apiClient.CreateUserAsync(user);

            Assert.Multiple(() =>
            {
                Assert.That(createdUser.Name, Is.EqualTo(user.Name), "User name is not correct!");
            });
        }
    }
}
