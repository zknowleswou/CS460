namespace Homework5.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RequestContext : DbContext
    {
        public RequestContext()
            : base("name=MorseConn")
        {
        }

        public virtual DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.ApartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.UnitNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Request>()
                .Property(e => e.DescriptionOfIssue)
                .IsUnicode(false);
        }
    }
}
