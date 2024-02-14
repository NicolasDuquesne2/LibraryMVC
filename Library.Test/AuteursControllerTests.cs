using LibraryMVC.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Test
{
    [TestClass]
    internal class AuteursControllerTests
    {
        [TestMethod]
        public async Task GetAuteursList()
        {
            /*var webHostBuilder = new WebHostBuilder().UseStartup<Startup>();
            using (var server = new TestServer(webHostBuilder))
            using (var client = server.CreateClient())
            {
                List<Auteur> result = await client.GetStringAsync("/api/auteurs");
                Assert.AreEqual("Soleil", result);
            }*/
        }
    }
}
