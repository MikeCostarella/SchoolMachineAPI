using Microsoft.AspNetCore.Mvc.Testing;
using SchoolMachine.API;
using System.Net.Http;

namespace SchoolMachine.Testing.API.Base
{
    public class SchoolMachineAPIIntegrationTestBase
    {
        public SchoolMachineAPIIntegrationTestBase()
        {
            WebApplicationFactory = new WebApplicationFactory<Startup>();
            Client = WebApplicationFactory.CreateClient();
        }

        public WebApplicationFactory<Startup> WebApplicationFactory { get; set; }
        public HttpClient Client { get; set; }
    }
}
