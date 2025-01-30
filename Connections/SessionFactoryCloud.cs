using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using Npgsql;

namespace ProyectXAPI.Connections
{
    public class SessionFactoryCloud

    {
        private SessionFactoryCloud() { }
        public static string ConnectionString;
        private static ISessionFactory session;
        private static NHibernate.ISession rootSession;

        private static ISessionFactory CreateSession<T>()
        {

            if (session != null)
                return session;

            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            var configMap =
                Fluently.Configure().Database(configDB).Mappings(
                    c => c.FluentMappings.AddFromAssemblyOf<T>());

            session = configMap.BuildSessionFactory();

            return session;
        }

        public static NHibernate.ISession Open<T>()
        {
            
            return CreateSession<T>().OpenSession();
        }
        public static NpgsqlConnection OpenNpgsqlConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(
                ConnectionString
            );
            conn.Open();
            return conn;
        }
    }
}
