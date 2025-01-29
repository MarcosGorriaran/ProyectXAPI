using FluentNHibernate.Mapping;
using ProyectXAPI.Models;

namespace ProyectXAPI.Maps
{
    public class SessionMap : ClassMap<Session>
    {
        const string TableName = "Sessions";
        public SessionMap()
        {
            Table(TableName);

            Id(x=>x.SessionID).Column("SESSIONID");
            Map(x => x.DateGame).Column("DateGame");
        }
    }
}
