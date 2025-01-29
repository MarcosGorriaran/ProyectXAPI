using FluentNHibernate.Mapping;
using ProyectXAPI.Models;

namespace ProyectXAPI.Maps
{
    public class SessionDataMap : ClassMap<SessionData>
    {
        const string TableName = "SessionData";
        public SessionDataMap()
        {
            Table(TableName);

            References(x=>x.Profile).Columns("P","");
        }
    }
}
