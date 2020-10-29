using Charles_Sadia_Lab3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
    //public class ApplicationDbContextFactory
    //        : IDesignTimeDbContextFactory<ApplicationDbContext>
    //{

    //    public ApplicationDbContext CreateDbContext(string[] args) =>
    //        Program.CreateHostBuilder.(args).Services
    //            .GetRequiredService<ApplicationDbContext>();
    //}
}
