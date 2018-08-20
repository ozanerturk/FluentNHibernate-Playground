using Domain.Enum;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernatePlayGround.Mapping
{
    public class BorrowingMap : ClassMap<Borrowing>
    {
        public BorrowingMap()
        {
            Table("Borrowing");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.StartDate)
                .Not.Nullable();
            Map(x => x.EndDate)
                .Not.Nullable();
            References(x => x.Student)
                .Not.Nullable()
                .Cascade.Delete();
            References(x => x.Book)
                .Not.Nullable()
                .Cascade.Delete();

        }

     
    }
}
