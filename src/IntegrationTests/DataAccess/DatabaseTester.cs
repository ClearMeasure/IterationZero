using System;
using Core;
using Infrastructure;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace IntegrationTests.DataAccess
{
    [TestFixture]
    public class DatabaseTester
    {
        [Test, Explicit, Category("DataSchema")]
        public void CreateDatabaseSchema()
        {
            var export = new SchemaExport(
                DataContext.BuildConfiguration());
            export.Execute(true, true, false);
        }

        public void Clean()
        {
            using (var session = DataContext.GetSession())
            {
                session.BeginTransaction();
                session.CreateQuery("delete from Visitor").ExecuteUpdate();
                session.Transaction.Commit();
            }
        }
    }
}