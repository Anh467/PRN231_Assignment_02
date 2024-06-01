using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Publisher
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PubId { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string PublisherName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? City { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? State { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Country { get; set; } 

        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
