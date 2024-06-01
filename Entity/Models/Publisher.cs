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
        [Column(name: "nvarchar(200)")]
        public string PublisherName { get; set; }
        [Column(name: "nvarchar(100)")]
        public string? City { get; set; }
        [Column(name: "varchar(20)")]
        public string? State { get; set; }
        [Column(name: "nvarchar(100)")]
        public string? Country { get; set; } 
    }
}
