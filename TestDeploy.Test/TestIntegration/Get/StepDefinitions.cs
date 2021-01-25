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

namespace TestDeploy.Test.TestIntegration.Get
{
    [Binding]
    [Scope(Feature = "Get Pet")]
    public class StepDefinitions
    {
        private readonly HttpClient client;
        private int id;
        private HttpResponseMessage response;
        private readonly WebApplicationFactory<TestDeploy.Web.Startup> factory;

        public StepDefinitions(WebApplicationFactory<TestDeploy.Web.Startup> factory)
        {
            this.factory = factory;
            this.client = factory.CreateClient();
        }

        [Given(@"A valid Get request")]
        public void GivenAValidGetRequest()
        {
            id = 0;
        }

        [When(@"A Get is called on pets")]
        public async Task WhenAGetIsCalledOnPets()
        {
            response = await client.GetAsync($"/pets/{id}");
        }

        [Then(@"it should Resturn (.*)")]
        public void ThenItShouldResturnOk(string status)
        {
            Assert.AreEqual(status, response.StatusCode.ToString());
        }

        [Then(@"Pet in response")]
        public async Task ThenPetInResponse()
        {
            Pet pet = await response.Content.ReadAsAsync<Pet>();
            Assert.AreEqual(pet.Name, "Dog");
        }
    }
}