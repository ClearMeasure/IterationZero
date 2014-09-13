using System;
using Core;
using Core.Model;
using Infrastructure;
using Infrastructure.DataAccess;
using NHibernate;
using NUnit.Framework;
using Should;

namespace IntegrationTests.DataAccess.Mappings
{
    [TestFixture]
    public class VisitorMappingTester
    {
        [Test]
        public void Should_map_Visitor()
        {
            DataContext.EnsureStartup();
            new DatabaseTester().Clean();
            var visitor = new Visitor
            {
                Browser = "1",
                IpAddress = "2",
                LoginName = "3",
                PathAndQuerystring = "4",
                VisitDate =
                    new DateTime(2000, 1, 1),
                FirstName = "Jones"
            };

            var repository = new VisitorRepository();
            repository.Save(visitor);

            Visitor loadedVisitor;
            using (ISession session = DataContext.GetSession())
            {
                loadedVisitor = session.Load<Visitor>(visitor.Id);
            }

            loadedVisitor.ShouldNotBeNull();
            loadedVisitor.Browser.ShouldEqual("1");
            loadedVisitor.IpAddress.ShouldEqual("2");
            loadedVisitor.LoginName.ShouldEqual("3");
            loadedVisitor.PathAndQuerystring.ShouldEqual("4");
            loadedVisitor.VisitDate.ShouldEqual(new DateTime(2000, 1, 1));
            loadedVisitor.FirstName.ShouldEqual("Jones");
        }
    }
}