using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLoans.Models
{
    public class LoansModel
    {
        public int Id { get; set; }
        public string? Receiver { get; set; }
        public string? Provider { get; set; }
        public string? BorrowedBook { get; set; }
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
    }
}