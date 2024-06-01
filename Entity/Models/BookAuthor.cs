using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entity.Models
{
    public class BookAuthor
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public string? AuthorOrder { get; set; }
        [Range(0,100, ErrorMessage = "Percentage just in range 0 to 100") ]
        public double RoyalityPercentage { get; set; }
    }
}
