using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ApiContext : System.Data.Entity.DbContext
    {
        static ApiContext()
        {
        }

        public ApiContext() : base(nameOrConnectionString: "DbContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            Configuration.AutoDetectChangesEnabled = true;


            modelBuilder.Entity<Customer>()
                .HasMany(x => x.RentedGames)
                .WithRequired(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<GameType>()
                .HasMany(x => x.Games)
                .WithRequired(x => x.GameType)
                .HasForeignKey(x => x.GameTypeId);

            modelBuilder.Entity<GameRent>()
                .HasRequired(x => x.Customer)
                .WithMany(x => x.RentedGames)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<GameRent>()
               .HasRequired(x => x.Game);
              


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<GameRent> RentedGames { get; set; }
    }
}
