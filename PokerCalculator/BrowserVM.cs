using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator
{
    public class BrowserVM
    {
        private List<PokerGame> games;

        BrowserVM() {

        }

        // retrieves list of games from db
        private void getGames() {
            using (var context = new AccountContext()) {
                Accounts = context.accounts.ToList();
            }
        }





    }
}
