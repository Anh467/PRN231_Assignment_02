using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Database
{
    public class AppDBContext : DbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<BookAuthor> BookAuthors { get; set; }
        DbSet<Publisher> Publishers { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }

        public AppDBContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MSSQL"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(a => new { a.AuthorId, a.BookId });
            modelBuilder.Entity<Role>()
                .HasData(new List<Role>
                {
                    new Role()
                    {
                        RoleId = (int) ModelConst.Role.Admin,
                        RoleDesc = "Person who can mange orther"
                    },
                    new Role()
                    {
                        RoleId = (int) ModelConst.Role.User,
                        RoleDesc = "Person who can participate the website"
                    }
                });
        }
    }
}
