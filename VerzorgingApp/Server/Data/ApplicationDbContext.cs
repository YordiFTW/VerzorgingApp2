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
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Caretaker> Caretakers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Medicine> Medcines { get; set; }
        public DbSet<Person> People { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Caretaker>()
                .HasMany(g => g.Elders)
                .WithOne(s => s.Caretaker)
                .HasForeignKey(s => s.CaretakerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>().HasData(
            new {
                Id = 1,
                Subject = "Explosion of Betelgeuse Star",
                Location = "Space Centre USA",
                StartTime = new DateTime(2020, 1, 5, 9, 30, 0),
                EndTime = new DateTime(2020, 1, 5, 11, 0, 0),
                CategoryColor = "#1aaa55"
            });
        }
    }

}
