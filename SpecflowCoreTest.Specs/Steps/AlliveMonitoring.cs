using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SpecflowCoreTest.Web;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit.Gherkin.Quick;

namespace SpecflowCoreTest.Specs.Steps
{
    [FeatureFile("../AliveMonitoring.feature")]
    public class AliveMonitoring
    {
        TestServer _server;
        HttpClient _client;
        HttpResponseMessage _response;

        [Given("the system is running")]
        public void The_system_is_running()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [When("a web request is recieved to the root URL")]
        public async Task A_web_request_is_recieved_to_the_root_URL()
        {
            _response = await _client.GetAsync("/api/values");
        }

        [Then(@"a response is returned with the HTTP status code (\d+")]
        public void A_response_is_returned_with_the_HTTP_status_code(int statusCode)
        {
            _response.StatusCode.Should().Be((HttpStatusCode)statusCode);
        }
    }
}
