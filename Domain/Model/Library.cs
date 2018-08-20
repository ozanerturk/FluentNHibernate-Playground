using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernatePlayGround
{
   public class Library
    {
        protected Library()
        {

        }

        public Library(string name)
        {
            this.Name = name;
            Books = new HashSet<Book>();
        }
        public virtual int Id{ get; protected set; }
        public virtual string Name{ get;  protected set; }
        public virtual ISet<Book> Books { get; protected set; }


    }
}
