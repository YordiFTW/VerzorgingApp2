using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VerzorgingApp.Server.Models;
using VerzorgingApp.Shared;

namespace VerzorgingApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Elder> Elders { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Caretaker> Caretakers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Medicine> Medcines { get; set; }
        public DbSet<Person> People { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Elder>()
                .HasOne(m => m.Caretaker)
                .WithOne()
                .HasForeignKey<Caretaker>()
                .OnDelete(DeleteBehavior.NoAction);


        }
    }

}
