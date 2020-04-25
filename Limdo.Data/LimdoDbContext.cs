using Limdo.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Limdo.Data
{
    public partial class LimdoDbContext : DbContext
    {
        public LimdoDbContext(DbContextOptions<LimdoDbContext> dbContext) : base(dbContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureEntitiesRelationship(modelBuilder);
        }

        private void ConfigureEntitiesRelationship(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<AppUser>(u => u.AppUser)
                .WithOne(au => au.User)
                .HasForeignKey<AppUser>(au => au.SubjectId).IsRequired();

            modelBuilder.Entity<AppUser>()
                .HasOne<Country>(a => a.Country)
                .WithMany(c => c.AppUsers)
                .HasForeignKey(a => a.CountryId);


            modelBuilder.Entity<AppUser>()
                .HasOne<PcoLicenceDetail>(au => au.PcoLicenceDetail)
                .WithOne(pld => pld.AppUser)
                .HasForeignKey<PcoLicenceDetail>(a => a.AppUserId).IsRequired();

            //modelBuilder.Entity<PcoLicenceDetail>()
            //    .HasOne<AppUser>(au => au.AppUser);
            //.WithOne(pld => pld.AppUser)
            //.HasForeignKey<PcoLicenceDetail>(a => a.AppUserId).IsRequired();

            //modelBuilder.Entity<AppUser>()
            //    .HasOne<AccountType>(a => a.AccountType)
            //    .WithMany(acctType => acctType.Accounts)
            //    .HasForeignKey(a => a.AccountTypeId).IsRequired();

            //modelBuilder.Entity<Account>()
            //    .HasOne<Currency>(a => a.Currency)
            //    .WithMany(cu => cu.Accounts)
            //    .HasForeignKey(a => a.CurrencyId).IsRequired();

            //modelBuilder.Entity<AccountTransaction>()
            //    .HasOne<Account>(at => at.Account)
            //    .WithMany(a => a.AccountTransactions)
            //    .HasForeignKey(a => a.AccountId).IsRequired();

            ////modelBuilder.Entity<AccountTransaction>()
            ////    .HasOne<AppUser>(at => at.AppUser)
            ////    .WithMany(au => au.AccountTransactions);


            //modelBuilder.Entity<AccountTransaction>()
            //    .HasOne<OrderByType>(at => at.OrderByType)
            //    .WithMany(ot => ot.AccountTransactions)
            //    .HasForeignKey(ot => ot.OrderByTypeId).IsRequired();

        }

        public virtual void Commit(CancellationToken cancellationToken)
        {
            base.SaveChangesAsync(cancellationToken);
        }

    }
}
