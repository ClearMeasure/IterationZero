using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.DataAccess;
using NHibernate;
using Should;
using NUnit.Framework;

namespace IntegrationTests.DataAccess
{
    [TestFixture]
    public class VisitorRepositoryTester
    {
        [Test]
        public void When_saving_should_write_to_database()
        {
            new DatabaseTester().Clean();
            var visitor = CreateVisitor(Convert.ToDateTime("1/2/2345"));

            var repository = new VisitorRepository();
            repository.Save(visitor);

            Visitor loadedVisitor;
            using (ISession session = DataContext.GetSession())
            {
                loadedVisitor = session.Load<Visitor>(
                    visitor.Id);
            }

            loadedVisitor.ShouldNotBeNull();
            loadedVisitor.VisitDate.ToShortDateString().ShouldEqual("1/2/2345");
        }

        [Test]
        public void Should_get_two_most_recent_visitors()
        {
            new DatabaseTester().Clean();
            Visitor visitor1 =
                CreateVisitor(new DateTime(2000, 1, 1));
            Visitor visitor2 =
                CreateVisitor(new DateTime(2000, 1, 2));
            Visitor visitor3 =
                CreateVisitor(new DateTime(2000, 1, 3));
            using (ISession session1 = DataContext.GetSession())
            {
                session1.BeginTransaction();
                session1.SaveOrUpdate(visitor1);
                session1.SaveOrUpdate(visitor2);
                session1.SaveOrUpdate(visitor3);
                session1.Transaction.Commit();
            }

            var repository = new VisitorRepository();
            Visitor[] recentVisitors =
                repository.GetRecentVisitors(2);

            recentVisitors.Length.ShouldEqual(2);
            IEnumerable<Guid> idList = recentVisitors.Select(x => x.Id);
            idList.Contains(visitor3.Id).ShouldBeTrue();
            idList.Contains(visitor2.Id).ShouldBeTrue();
            idList.Contains(visitor1.Id).ShouldBeFalse();
        }

        private Visitor CreateVisitor(DateTime visitDate)
        {
            return new Visitor
                       {
                           Browser = "1",
                           IpAddress = "2",
                           LoginName = "3",
                           PathAndQuerystring = "4",
                           VisitDate = visitDate
                       };
        }
    }
}