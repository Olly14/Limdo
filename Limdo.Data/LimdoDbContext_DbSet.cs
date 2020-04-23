using Limdo.Domain;
using Microsoft.EntityFrameworkCore;


namespace Limdo.Data
{
    public partial class LimdoDbContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<PcoLicenceDetail> PcoDetails { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}
