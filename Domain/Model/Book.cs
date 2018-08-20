using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernatePlayGround
{
   public class Book
    {
        protected Book()
        {

        }
        public Book(string name,DateTime dateWritten)
        {
            this.Name = name;
            this.DateWritten = dateWritten;
        }

        public virtual int Id{ get; protected set; }
        public virtual string  Name{ get; protected set; }
        public virtual DateTime DateWritten { get; protected set; }
        public virtual int ReadCount { get; protected set; }
        public virtual BookStatus Status { get; protected set; }
        public virtual void UpdateStatus (BookStatus status)
        {
            this.Status = status;
        }
        public virtual void IncreaseReadCount()
        {
            ReadCount++;
        }
    }
}
