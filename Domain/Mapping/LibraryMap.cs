using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernatePlayGround.Mapping
{
    public class LibraryMap : ClassMap<Library>
    {
        public LibraryMap()
        {
            Table("Libraries");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            HasMany(x => x.Books)
                .Not.KeyNullable()
                .Not.KeyUpdate()
                .Cascade.AllDeleteOrphan();
        }
    }
}
