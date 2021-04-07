using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using FCManagement.DAL.IMPL;
using FitnessClubManagement.CRUD.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace FCManagement.IntegrationTests.Util
{
    public class BaseTestFixture
    {
        public TestServer TestServer { get; }
        public FitnessDbContext DbContext { get; }
        public HttpClient Client { get; }

        public BaseTestFixture()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            TestServer = new TestServer(builder);
            Client = TestServer.CreateClient();
            DbContext = TestServer.Host.Services.GetService<FitnessDbContext>();

            FakeDbInitializer.Initialize(DbContext);

        }

        public void Dispose()
        {
            Client.Dispose();
            TestServer.Dispose();
        }
    }
}
