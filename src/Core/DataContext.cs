using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;

namespace Core
{
    public class DataContext
    {
        private static ISessionFactory _sessionFactory;
        private static bool _startupComplete = false;

        private static readonly object _locker =
            new object();

        public static ISession GetSession()
        {
            EnsureStartup();
            ISession session = _sessionFactory.OpenSession();
            session.BeginTransaction();
            return session;
        }

        public static void EnsureStartup()
        {
            if (!_startupComplete)
            {
                lock (_locker)
                {
                    if (!_startupComplete)
                    {
                        InitializeSessionFactory();
                        _startupComplete = true;
                    }
                }
            }
        }

        private static void InitializeSessionFactory()
        {
            Configuration configuration =
                BuildConfiguration();
            _sessionFactory =
                configuration.BuildSessionFactory();
        }

        public static Configuration BuildConfiguration()
        {
            var config = new Configuration().Configure();
            var fluentConfig = Fluently.Configure(config);
            var loadedConfig = fluentConfig.Mappings(x =>
                x.FluentMappings.AddFromAssemblyOf<DataContext>());
            return loadedConfig.BuildConfiguration();
        }
    }
}