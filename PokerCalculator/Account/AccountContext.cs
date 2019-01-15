using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PokerCalculator {
    class AccountContext : DbContext {

        public DbSet<Account> accounts { get; set; }

        public AccountContext() : base(nameOrConnectionString: "postgresPokerCalc") {
            Database.SetInitializer<AccountContext>(null);
            //Database.SetInitializer<PlayerContext>(new DropCreateDatabaseIfModelChanges<PlayerContext>());
        }

        protected override void OnModelCreating(DbModelBuilder mb) {
            mb.HasDefaultSchema("public");
            base.OnModelCreating(mb);

            /*mb.Entity<Player>()
                .Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar");

            mb.Entity<Player>()
                .Property(p => p.Stack)
                .HasColumnName("Name")
                .HasColumnType("varchar");*/

            //mb.HasDefaultSchema("public");
            //Database.SetInitializer<PlayerContext>(null); // used to replace schema
            //base.OnModelCreating(mb);
        }

    }
}
