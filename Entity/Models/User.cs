using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    [Index(nameof(EmailAddress), IsUnique = true)]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Column(name:"varchar(200)")]
        public string EmailAddress { get; set; }
        [Column(name: "varchar(100)")]
        public string Password { get; set; }
        [Column(name: "nvarchar(100)")]
        public string? Source { get; set; }
        [Column(name: "varchar(50)")]
        public string FirstName {  get; set; }
        [Column(name: "varchar(50)")]
        public string MiddleName { get; set; }
        [Column(name: "varchar(50)")]
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public int PubId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime HireDate {  get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role? Role { get; set; }
        [ForeignKey(nameof(PubId))]
        public virtual Publisher? Publisher { get; set; }
    }
}
