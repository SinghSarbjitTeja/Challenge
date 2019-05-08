using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.Persistence.Models;

namespace Product.Persistence.DBContexts
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }
        public DbSet<Contacts> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>().HasData(
                new Contacts
                {
                    Id = 1,
                    Name = "Electronics",
                    Email = "El@dmil.com",
                    Phone = "1111",
                }
            );
        }

    }
}
