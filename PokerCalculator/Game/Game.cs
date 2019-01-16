using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator
{
    [Table("games", Schema = "public")]
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; private set; }

        [Required]
        public int cards { get; private set; }
        [Required]
        public int seats { get; private set; }

        [Required]
        public double timer { get; private set; }
        [Required]
        public double timebank { get; private set; }

        [Required]
        public double bb { get; private set; }
        [Required]
        public double sb { get; private set; }
        [Required]
        public double ante { get; private set; }
        [Required]
        public double max_buyin { get; private set; }
        [Required]
        public double min_buyin { get; private set; }

        private Game() { }

        public Game(int numberOfSeats, int cardsPerHand, double bb, double ante=0, double maxBuyInFactor=100, double minBuyInFactor=25, double defaultTimer=30, double defaultTimeBank=30) {
            this.seats = numberOfSeats;
            this.cards = cardsPerHand;
            this.bb = bb;
            this.sb = bb / 2;
            this.ante = ante;
            this.max_buyin = bb * maxBuyInFactor;
            this.min_buyin = bb * minBuyInFactor;
            this.timer = defaultTimer;
            this.timebank = defaultTimeBank;
        }
    }
}
