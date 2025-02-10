using FluentNHibernate.Mapping;
using ProyectXAPI.Models;

namespace ProyectXAPI.Maps
{
    public class AcountMap : ClassMap<Acount>
    {
        const string TableName = "Acounts";
        public AcountMap() 
        {
            Table(TableName);
            Id(x => x.Username).Column("USERNAME");
            Map(x => x.Password).Column("PASSWORD");
        }
    }
}
