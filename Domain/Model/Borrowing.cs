using System;
using System.Collections.Generic;
using System.Linq;

namespace NhibernatePlayGround
{
    public  class Borrowing
    {
        protected Borrowing()
        {

        }
        public Borrowing(Book book,Student student, DateTime startDate, DateTime endDate)
        {
            this.Book = book;
            this.Student = student;
            this.StartDate = startDate;
            this.EndDate= endDate;
            
          
        }

        public virtual int Id { get; protected set; }
        public virtual Book Book { get; protected set; }
        public virtual DateTime StartDate { get; protected set; }
        public virtual DateTime EndDate{ get; protected set; }
        public virtual Student Student { get; set; }

     
    }
}