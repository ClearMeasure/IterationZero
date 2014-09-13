using System.Linq;
using Core;
using NHibernate;
using NHibernate.Linq;

namespace Infrastructure
{
    public class VisitorRepository : IVisitorRepository
    {
        public void Save(Visitor visitor)
        {
            using (ISession session = DataConfig.GetSession())
            {
                session.BeginTransaction();
                session.SaveOrUpdate(visitor);
                session.Transaction.Commit();
            }
        }

        public Visitor[] GetRecentVisitors(int numberOfVisitors)
        {
            using (ISession session = DataConfig.GetSession())
            {
                Visitor[] recentVisitors =
                    session.Query<Visitor>()
                        .OrderByDescending(v => v.VisitDate)
                        .Take(numberOfVisitors)
                        .ToArray();

                return recentVisitors;
            }
        }
    }
}

//          ***If we were to use HQL***
//            IList<Visitor> visitors = session
//                .CreateQuery("select v from Visitor v order by v.VisitDate desc")
//                .SetMaxResults(numberOfVisitors)
//                .List<Visitor>();
//
//            return visitors.ToArray();