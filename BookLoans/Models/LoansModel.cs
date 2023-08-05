using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace BookLoans.Models
{
    public class LoansModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the recipient's name!")]
        public string? Receiver { get; set; }

        [Required(ErrorMessage = "Enter the name of the supplier!")]
        public string? Provider { get; set; }

        [Required(ErrorMessage = "Enter the name of the book!")]
        public string? BorrowedBook { get; set; }

        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
    }
}