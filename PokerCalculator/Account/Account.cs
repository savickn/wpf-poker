using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCalculator {
    [Table("accounts", Schema = "public")]
    public class Account {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public double money { get; set; }

        public Account() {}

        public Account(string name, double money=0) {
            this.name = name;
            this.money = money;
        }
    }
}
