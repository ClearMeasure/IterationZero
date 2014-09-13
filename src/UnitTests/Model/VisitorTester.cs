using Core.Model;
using NUnit.Framework;
using Should;

namespace UnitTests.Model
{
    [TestFixture]
    public class VisitorTester
    {
        [Test]
        public void Should_serialize_to_full_name()
        {
            var visitor = new Visitor(){FirstName = "Jeffrey", LastName = "Palermo"};
            string serializedRepresentation = visitor.ToString();

            serializedRepresentation.ShouldEqual("Jeffrey Palermo");
        }
    }
}