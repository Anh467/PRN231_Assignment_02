using DataAccess.Implements;
using Entity.Database;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using QuanLyChiHoi.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUnitOfWork
    {
        IGenericRepository<Author> _author { get; }
        IGenericRepository<BookAuthor> _bookAuthor { get; }
        IGenericRepository<Book> _book { get; }
        IGenericRepository<Publisher> _publisher { get; }
        IGenericRepository<Role> _role { get; }
        IGenericRepository<User> _user { get; }
    }
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Author> _author { get; private set; }

        public IGenericRepository<BookAuthor> _bookAuthor { get; private set; }

        public IGenericRepository<Book> _book { get; private set; }

        public IGenericRepository<Publisher> _publisher { get; private set; }

        public IGenericRepository<Role> _role { get; private set; }

        public IGenericRepository<User> _user { get; private set; }

        public UnitOfWork()
        {
            _author = new AuthorRepository();
            _bookAuthor = new BookAuthorRepository();   
            _book = new BookRepository();
            _publisher = new PublisherRepository(); 
            _role = new RoleRepository();
            _user = new UserRepository();
        }
    }
}
