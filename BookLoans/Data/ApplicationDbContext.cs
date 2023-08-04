using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLoans.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLoans.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<LoansModel> Loans { get; set; }
    }
}