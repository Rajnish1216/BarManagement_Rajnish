using System;
using System.Collections.Generic;
using System.Text;
using BarManagement_Rajnish.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarManagement_Rajnish.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WineBrand> WineBrands { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
