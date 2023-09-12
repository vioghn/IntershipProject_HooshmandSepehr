using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purse.Domain.Entites;
using Purse.Infrastructure.Data.Config;


namespace Purse.Infrastructure.Data
{
    public class PurseDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PurseM> Purses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public PurseDbContext(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // to identify to db our configurations
        {
             modelBuilder.ApplyConfiguration(new UserConfig());
             modelBuilder.ApplyConfiguration(new PurseConfig());
             modelBuilder.ApplyConfiguration(new CompanyConfig());
             modelBuilder.ApplyConfiguration(new TransactionConfig());
            modelBuilder.ApplyConfiguration(new VoacherConfig());




        }
        public class BloggingContextFactory : IDesignTimeDbContextFactory<PurseDbContext>
        {
            public PurseDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<PurseDbContext>();
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-CMR9S4V;Database=DemoDb;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
                return new PurseDbContext(optionsBuilder.Options);


            }
        }


    }
}
