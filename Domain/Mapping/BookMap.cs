using Domain.Enum;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernatePlayGround.Mapping
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Table("Books");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name)
                .Not.Nullable();
            Map(x => x.DateWritten)
                .Not.Nullable();
            Map(x => x.Status)
                .CustomType<BookStatus>()
                .Not.Nullable();

        }

     
    }
}
