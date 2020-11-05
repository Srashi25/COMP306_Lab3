using Group4_Lab3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group4_Lab3.DbData
{
    public class MovieAppDbContext: DbContext
    {
        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder.UseSqlServer($"Server=moviesdblab3.cpgfkgne7e1e.us-east-2.rds.amazonaws.com;Database=moviewebdb; User Id= admin; Password: password");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
