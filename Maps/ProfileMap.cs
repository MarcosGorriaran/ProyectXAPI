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
                .KeyProperty(x => x.Id, "ProfileID")
                .KeyReference(x => x.Creator, "CREATOR");
            Map(x => x.ProfileName, "PROFILE_NAME");
        }
    }
}
