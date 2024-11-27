using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLab1.Models
{
    public class Transaction
    {
        [Key]
        public int TID { get; set; }

        [Required]
        public  string sourceAccNumber { get; set; }

        [Required]
        public bool operation {  get; set; }    //true for plus false for minus

        [Required]
        public decimal amount { get; set; }

        [Required]
        [ForeignKey(nameof(DestinationAccount))]
        public int Id { get; set; }
        public virtual BankAccount DestinationAccount { get; set; }

    }
}
