
using Game.Module.BusinessObjects;
using Game.Module.Functions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var configuration = new ConfigurationBuilder()
     .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("ConnectionString");
            var factory = new MyGameEFCoreDbContextFactory();
            Debug.Print("Testing Add");
            factory.TestAdd(connectionString);
        }
    }
}