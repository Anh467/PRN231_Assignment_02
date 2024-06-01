using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorID { get; set; }
        [Column(name:"nvarchar(50)")]
        public string LastName { get; set; }
        [Column(name: "nvarchar(50)")]
        public string FirstName { get; set; }
        [Length(10, 10, ErrorMessage ="Phone must have 10 number characters")]
        public string Phone { get; set; }
        [Column(name:"nvarchar(300)")]
        public string? Address { get; set; }
        [Column(name: "nvarchar(50)")]
        public string? City { get; set; }
        [Column(name: "nvarchar(50)")]
        public string? State { get; set; }
        [Column(name: "nvarchar(50)")]
        public string? Zip { get; set; }
        [Column(name: "nvarchar(200)")]
        public string EmailAddress { get; set; }
    }
}
