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

            CompositeId()
                .KeyReference(x => x.Profile, "PROFILE", "PROFILECREATOR")
                .KeyReference(x => x.Session, "SESSION");

            Map(x => x.Kills).Column("KILLS");
            Map(x => x.Deaths).Column("DEATHS");
        }
    }
}
