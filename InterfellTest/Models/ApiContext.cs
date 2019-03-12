using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfellTest
{
    public class ApiContext : System.Data.Entity.DbContext
    {
        static ApiContext()
        {
        }

        public ApiContext() : base(nameOrConnectionString: "DbContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            Configuration.AutoDetectChangesEnabled = true;


        

            modelBuilder.Entity<GameType>()
                .HasMany(x => x.Games)
                .WithRequired(x => x.GameType)
                .HasForeignKey(x => x.GameTypeId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
    }
}
