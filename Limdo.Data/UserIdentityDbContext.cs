using Limdo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Limdo.Data
{
    public class UserIdentityDbContext : DbContext
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureEntitiesRelationship(modelBuilder);
        }

        private void ConfigureEntitiesRelationship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserClaim>()
                .HasOne<User>(uc => uc.User)
                .WithMany(u => u.Claims)
                .HasForeignKey(au => au.SubjectId).IsRequired();

            modelBuilder.Entity<UserLogin>()
                    .HasOne<User>(ul => ul.User)
                    .WithMany(u => u.Logins)
                    .HasForeignKey(ul => ul.SubjectId);

        }




        public DbSet<User> Users { get; set; }
        public DbSet<User> Claims { get; set; }
        public DbSet<User> Logins { get; set; }




    }
}
