using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Type {  get; set; }
        public int PubId { get; set; }
        [Range(0, double.MaxValue, ErrorMessage ="Cannot enter money less than 0")]
        public decimal Price { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Advance {  get; set; }
        public decimal Royality { get; set; }
        public int ytd_sales { get; set; }
        [Column(TypeName ="nvarchar(300)")]
        public string Notes { get; set; }
        public DateTime PublishedDate {  get; set; }

        [ForeignKey(nameof(PubId))]
        public virtual Publisher? Publisher { get; set; }
        public virtual ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
