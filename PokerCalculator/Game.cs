using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    class Game {
        bool isPreflop;
        bool isHeadsUp;
        string state;

        Player playerToAct;

        Table table;
        string street;
        Deck deck { get; }
        Board board { get; }

        int cardsPerHand;

        int currentBet;
        int minRaise;
        int maxBet;

        Seat btn;
        Seat sb;
        Seat bb;
        Seat fp;

        int bigBlind;
        int smallBlind;
        int ante;
        int maxBuyin;
        int minBuyin;
        double timer;

        public Game() {

        }

        ///// PLAYER POSITIONING /////

        public void assignPositions() {

        }

        public void rotatePlayers() {
            this.btn = this.btn.getNearestLeftSeatWithActivePlayer();
            this.sb = this.sb.getNearestLeftSeatWithActivePlayer();
            this.bb = this.bb.getNearestLeftSeatWithActivePlayer();
            this.fp = this.fp.getNearestLeftSeatWithActivePlayer();
        }

        ///// PLAYER HAND GENERATION /////

        public void generateHands(List<Player> activePlayers) {

        }

        public void dealHand(Player player, List<Card> cards) {
            PreflopHand hand = HoldemHand(cards);
            player.setHand(hand);
        }

        ///// POSTING BLINDS /////

        public void postBB(List<Player> players) {
            Player bb = this.postBB.getPlayer();



        }

        public void postSB(List<Player> players) {

        }

        public void postAnte(List<Player> players) {

        }

        ///// BOARD GENERATION /////

        public void burnCard() {

        }

        public void generateFlop() {

        }

        public void generateTurn() {

        }

        public void generateRiver() {

        }

        ///// PLAYER BETTING /////

        public void preFlopBetting() {

        }

        public void postFlopBetting() {

        }

        public void bettingRound(startingSeat) {

        }


        ///// GAME LOGIC /////

        public void initializeGame() {

        }

        public void run() {

        }

        public void startRound(List<Player> activePlayers) {

        }

        public void handleEndgame() {

        }



    }
}
