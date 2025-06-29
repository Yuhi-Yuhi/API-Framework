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
    }
}
