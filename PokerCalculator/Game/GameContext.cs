using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator
{
    public class GameContext : DbContext
    {
        public DbSet<Game> games { get; set; }

        public GameContext() : base(nameOrConnectionString: "postgresPokerCalc") {
            Database.SetInitializer<GameContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder mb) {
            mb.HasDefaultSchema("public");
            base.OnModelCreating(mb);
        }
    }
}
