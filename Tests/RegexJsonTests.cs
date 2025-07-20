using System.Text.RegularExpressions;
using NUnit.Framework;
using Serilog;

namespace Framework
{
    [TestFixture]
    public class RegexJsonTests : TestBase
    {
        private string json = @"{
          ""userId"": ""A12-456-B8"",
          ""email"": ""test.user@example.com"",
          ""ip"": ""192.168.0.105"",
          ""mac"": ""00:1B:44:11:3A:B7"",
          ""guid"": ""a3f50fce-51b1-4f8e-93c0-4f0a3b4e6b94"",
          ""phone"": ""+1-800-555-0299"",
          ""createdAt"": ""2024-05-30T12:34:56Z"",
          ""tags"": [""alpha"", ""beta"", ""release-2025""],
          ""deviceId"": ""DEV-87456-XYZ"",
          ""url"": ""https://api.example.com/v1/user/123/profile""
        }";

        [Test]
        [Repeat(2)]
        [Category("Smoke")]
        public void FindPhoneNumber()
        {
            string pattern = @"\+\d{1}-\d{3}-\d{3}-\d{4}";
            Match match = Regex.Match(json, pattern);
            Log.Information(match.Success ? $"Found: {match.Value}" : "Was not found");
            Assert.That(match.Success, Is.True, $"Element was not found by specified regex: `{pattern}`");
        }

        [Test]
        public void FindUserId()
        {
            string pattern = @"([A-Z]\d{2}-\d{3}-[A-Z]\d)";
            Match match = Regex.Match(json, pattern);
            Log.Information(match.Success ? $"Found: {match.Value}" : "Was not found");
            Assert.That(match.Success, Is.True, $"userId was not found by specified regex: `{pattern}`");
        }

        [Test]
        public void FindEmail()
        {
            string pattern = @"([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})";
            Match match = Regex.Match(json, pattern);
            Log.Information(match.Success ? $"Found: {match.Value}" : "Was not found");
            Assert.That(match.Success, Is.True, $"email was not found by specified regex: `{pattern}`");
        }

        [Test]
        public void FindIpAddress()
        {
            string pattern = @"(\d{1,3}\.\d{1,3}\.\d{1}\.\d{1,3})";
            Match match = Regex.Match(json, pattern);
            Log.Information(match.Success ? $"Found: {match.Value}" : "Was not found");
            Assert.That(match.Success, Is.True, $"ip was not found by specified regex: `{pattern}`");
        }

        [Test]
        public void FindMacAddress()
        {
            string pattern = @"([0-9A-Fa-f]{2}(:[0-9A-Fa-f]{2}){5})";
            Match match = Regex.Match(json, pattern);
            Log.Information(match.Success ? $"Found: {match.Value}" : "Was not found");
            Assert.That(match.Success, Is.True, $"mac was not found by specified regex: `{pattern}`");
        }

        [Test]
        public void FindGuid()
        {
            string pattern = @"([a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12})";
            Match match = Regex.Match(json, pattern);
            Log.Information(match.Success ? $"Found: {match.Value}" : "Was not found");
            Assert.That(match.Success, Is.True, $"guid was not found by specified regex: `{pattern}`");
        }

        [Test]
        public void FindCreatedAt()
        {
            string pattern = @"(\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}Z)";
            Match match = Regex.Match(json, pattern);
            Log.Information(match.Success ? $"Found: {match.Value}" : "Was not found");
            Assert.That(match.Success, Is.True, $"createdAt was not found by specified regex: `{pattern}`");
        }

        [Test]
        public void FindDeviceId()
        {
            string pattern = @"(DEV-\d{5}-[A-Z]{3})";
            Match match = Regex.Match(json, pattern);
            Log.Information(match.Success ? $"Found: {match.Value}" : "Was not found");
            Assert.That(match.Success, Is.True, $"deviceId was not found by specified regex: `{pattern}`");
        }

        [Test]
        public void FindUrl()
        {
            string pattern = @"(https?://[a-zA-Z0-9./_-]+)";
            Match match = Regex.Match(json, pattern);
            Log.Information(match.Success ? $"Found: {match.Value}" : "Was not found");
            Assert.That(match.Success, Is.True, $"url was not found by specified regex: `{pattern}`");
        }
    }
}

