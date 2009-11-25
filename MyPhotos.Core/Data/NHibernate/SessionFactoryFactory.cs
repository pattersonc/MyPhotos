using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MyPhotos.Core.Data.NHibernate.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace MyPhotos.Core.Data.NHibernate
{
    public static class SessionFactoryFactory
    {
        private static Configuration _configuration;
        private static ISessionFactory _sessionFactory;

        private static string ConnectionString
        {
            get { return @"Data Source=.\sqlexpress;Initial Catalog=MyPhotos;Integrated Security=True;"; }
        }

        private static Configuration Configuration
        {
            get
            {
                if(_configuration == null)
                    _configuration = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString))
                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<PhotoMap>()).BuildConfiguration();

                return _configuration;
            }
        }

        public static ISessionFactory CreateSessionFactory()
        {
            if(_sessionFactory == null)
                _sessionFactory = Configuration.BuildSessionFactory();

            return _sessionFactory;
        }

        public static void DropSchema()
        {
            new SchemaExport(Configuration).Drop(false, true);
        }

        public static void CreateSchema()
        {
            new SchemaExport(Configuration).Create(false, true);
        }
    }
}