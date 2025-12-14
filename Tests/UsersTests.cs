using Framework.Common;
using Framework.Common.Http;
using NUnit.Framework;
using Serilog;
using User = Framework.Models.User;

namespace Framework.Tests
{
    [TestFixture]
    public class UsersTests : TestBase
    {
        private FuturamaApiClient apiClient;
        private string url;

        [SetUp]
        public void Initialize()
        {
            var httpClient = HttpClientProvider.Create();
            apiClient = new FuturamaApiClient(httpClient);

            Log.Information("Running tests against {BaseUrl}", httpClient.BaseAddress);
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
                Password = "123123",
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
