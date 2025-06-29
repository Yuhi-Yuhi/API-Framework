using Framework.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Serilog;

namespace Framework
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
        }

        [SetUp]
        public void Setup()
        {
            Log.Information("Test was started!");
        }

        [TearDown]
        public void Teardown()
        {
            Log.Information("Test was finished!");
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {

        }
    }
}
