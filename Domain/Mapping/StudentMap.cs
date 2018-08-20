using Domain.Enum;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernatePlayGround.Mapping
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name)
                .Not.Nullable();
            Map(x => x.Number)
                .Not.Nullable();
            HasMany(x => x.Borrowing)
                .Inverse()
                .Not.KeyNullable()
                .Not.KeyUpdate()
                .Cascade.AllDeleteOrphan();

        }

     
    }
}
