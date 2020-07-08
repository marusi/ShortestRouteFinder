using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Microsoft.EntityFrameworkCore.Design;
using RouteSafi.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RouteSafi.Infrastructure
{
    public class AppDbContext : DbContext
    {


        //  tables

        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Document> Documents { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




        }









    }
}
