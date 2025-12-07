using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Serilog;
using Allure.NUnit;

namespace Framework
{
    [AllureNUnit]
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

            Log.Information("=== TEST RUN STARTED ===");
        }

        [SetUp]
        public void Setup()
        {
            Log.Information($"START TEST: {TestContext.CurrentContext.Test.Name}");
        }

        [TearDown]
        public void Teardown()
        {
            Log.Information($"TEST FINISHED WITH STATUS: {TestContext.CurrentContext.Result.Outcome.Status}");
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            Log.Information("=== TEST RUN FINISHED ===");
            Log.CloseAndFlush();
        }
    }
}
