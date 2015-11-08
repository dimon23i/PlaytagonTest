using NHibernate;
using NHibernate.Cfg;

namespace PlaytagonTest.DAL
{
    public sealed class DbContext
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
//                    new SchemaExport(configuration).Execute(true,true,false);
//                    configuration.AddAssembly(typeof(Character).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
