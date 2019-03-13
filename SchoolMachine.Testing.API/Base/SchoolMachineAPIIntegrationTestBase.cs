using Microsoft.AspNetCore.Mvc.Testing;
using SchoolMachine.API;
using System.Net.Http;

namespace SchoolMachine.Testing.API.Base
{
    public class SchoolMachineApiIntegrationTestBase
    {
        #region Constructors

        public SchoolMachineApiIntegrationTestBase()
        {
            WebApplicationFactory = new WebApplicationFactory<Startup>();
            Client = WebApplicationFactory.CreateClient();
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// A factory to create a test server for the SchoolMachineAPI project
        /// </summary>
        public WebApplicationFactory<Startup> WebApplicationFactory { get; set; }

        /// <summary>
        /// An http client to make service calls to SchoolMachineAPI
        /// </summary>
        public HttpClient Client { get; set; }

        #endregion Public Properties
    }
}
