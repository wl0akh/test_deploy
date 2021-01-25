using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestDeploy.Web;

namespace TestDeploy.Test.TestIntegration.Create
{
    [Binding]
    [Scope(Feature = "Create Pet")]
    public class StepDefinitions
    {
        private readonly HttpClient client;
        private HttpContent body;
        private HttpResponseMessage response;
        private readonly WebApplicationFactory<TestDeploy.Web.Startup> factory;

        public StepDefinitions(WebApplicationFactory<TestDeploy.Web.Startup> factory)
        {
            this.factory = factory;
            this.client = factory.CreateClient();
        }
        [Given(@"A valid Post request with (.*), (.*) and (.*)")]
        public void GivenAValidPostRequestWithCatAnd(string name, DateTime dob, int temp)
        {
            body = new StringContent(
                JsonSerializer.Serialize(
                    new Pet
                    {
                        Name = name,
                        DOB = dob,
                        TemperatureC = temp
                    }
                ),
                Encoding.UTF8,
                "application/json"
            );
        }

        [When(@"A Post on called on pets")]
        public async Task WhenAPostOnCalledOnPets()
        {
            response = await client.PostAsync("/pets", body);
        }

        [Then(@"it should Resturn (.*)")]
        public void ThenItShouldResturnCreted(string status)
        {
            Assert.AreEqual(status, response.StatusCode.ToString());
        }

        [Then(@"Pet Id in Header")]
        public void ThenPetIdInHeader()
        {
            Assert.AreEqual(response.Headers.GetValues("htr").FirstOrDefault(), $"/pets/0");
        }
    }
}