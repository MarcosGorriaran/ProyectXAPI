using FluentNHibernate.Mapping;
using ProyectXAPI.Models;

namespace ProyectXAPI.Maps
{
    public class ProfileMap : ClassMap<Profile>
    {
        const string TableName = "Profiles";
        public ProfileMap()
        {
            Table(TableName);

            CompositeId()
                .KeyProperty(x => x.ProfileName, "PROFILENAME")
                .KeyReference(x => x.Creator, "CREATOR");
        }
    }
}
