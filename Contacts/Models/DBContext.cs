using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public class ContactsDBContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Incident> Incidents { get; set; }

        public ContactsDBContext(DbContextOptions<ContactsDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentConfiguration());
        }
    }

    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(x => x.Contact).WithMany(y => y.Accounts).HasForeignKey(z => z.ContactId);
            builder.HasIndex(x => x.Name).IsUnique();
            
        }
    }

    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasOne(x => x.Account).WithMany(y => y.Incidents).HasForeignKey(z => z.AccountName);
        }
    }

    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();
        }
    }




}
