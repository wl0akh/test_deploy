using NUnit.Framework;
using TestDeploy.Web;

namespace TestDeploy.TestUnit
{
    public class CreatePetTest
    {
        private Pet p;
        [SetUp]
        public void Setup()
        {
            p = new Pet();
        }

        [Test]
        public void Test1()
        {
            p.Name = "Adil";
            Assert.True(p.Name == "Adil", "Set Name Passed ");
        }
    }
}