using System;
using Core;
using Core.Model;
using Infrastructure;
using Infrastructure.DataAccess;
using IntegrationTests.DataAccess;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture, Explicit]
    public class ZDataLoader
    {
        [Test, Category("DataLoader")]
        public void LoadData()
        {
            new DatabaseTester().Clean();
            using (var session = DataContext.GetSession())
            {
                session.BeginTransaction();
                session.SaveOrUpdate(new Visitor()
                                         {
                                             Browser = "browser",
                                             IpAddress = "ip",
                                             LoginName = "login",
                                             PathAndQuerystring = "path",
                                             VisitDate = DateTime.Now
                                         });
                session.Transaction.Commit();
            }
        }
    }
}
