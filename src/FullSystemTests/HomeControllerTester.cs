using System.Text.RegularExpressions;
using System.Threading;
using IntegrationTests.DataAccess;
using NUnit.Framework;
using WatiN.Core;
using Should;

namespace FullSystemTests
{
    [TestFixture]
    public class HomeControllerTester
    {
        [Test]
        public void Should_save_a_visit()
        {
            new DatabaseTester().Clean();

            var url = "http://localhost:1234/";
            using (var ie = new IE(url))
            {
                ie.TextField("PathAndQuerystring").TypeText("/MyUrl");
                ie.TextField("LoginName").TypeText("SomeComputer\\ThisUser");
                ie.Button("submit").Click();

                ie.ContainsText("/MyUrl");
                ie.ContainsText("SomeComputer\\ThisUser").ShouldBeTrue();
            }
        }

        [Test, Explicit]
        public void Demonstrate_speed()
        {
            new DatabaseTester().Clean();

            var url = "http://localhost:1234/";
            using (var ie = new IE(url))
            {
                for (int i = 0; i < 50; i++)
                {
                    ie.GoTo("http://localhost:1234/");
                    ie.TextField("PathAndQuerystring").Value = "/MyUrl";
                    ie.TextField("LoginName").Value = "SomeComputer\\ThisUser";
                    ie.Button("submit").Click();

                    ie.ContainsText("/MyUrl");
                    ie.ContainsText("SomeComputer\\ThisUser").ShouldBeTrue();
                }
                
            }
        }

        [Test]
        public void Should_add_three_visits()
        {
            new DatabaseTester().Clean();

            var url = "http://localhost:1234/";
            using (var ie = new IE(url))
            {
                ie.Button("submit").Click();
                Thread.Sleep(2000);
                ie.Button("submit").Click();
                Thread.Sleep(2000);
                ie.Button("submit").Click();
                Thread.Sleep(2000);

                ie.ElementsWithTag("hr").Count.ShouldEqual(3);
            }
        }
    }
}
