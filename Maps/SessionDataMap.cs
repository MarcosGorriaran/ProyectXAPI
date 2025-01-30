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

            References(x=>x.Profile).Columns("PROFILE","PROFILECREATOR");
            References(x => x.Session).Columns("SESSIONID");
            Map(x => x.Kills).Column("KILLS");
            Map(x => x.Deaths).Column("DEATHS");
        }
    }
}
