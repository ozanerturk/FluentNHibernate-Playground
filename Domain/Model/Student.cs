using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernatePlayGround
{
   public class Student
    {
        protected Student()
        {

        }
        public Student(string name,int number)
        {
            this.Name = name;
            this.Number = number;
            Borrowing = new HashSet<Borrowing>();
        }

        public virtual int Id{ get; protected set; }
        public virtual string  Name{ get; protected set; }
        public virtual int Number{ get; protected set; }
        public virtual ISet<Borrowing>  Borrowing { get; protected set; }


    }
}
