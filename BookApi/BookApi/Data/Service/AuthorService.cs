using BookApi.Data.Model;
using BookApi.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data.Service
{
    public class AuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public List<AuthorWithBookVM> GetAllAuthorwithBook()
        {
            var _AuthorWithBookVM = _context.Authors.Select(n => new AuthorWithBookVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(x => x.Book.Title).ToList()
            }).ToList();

            return _AuthorWithBookVM;
        }

        public AuthorWithBookVM GetAuthorWithBookById(int authorid)
        {
            var _AuthorWithBookVM = _context.Authors.Where(x => x.Id == authorid).Select(n => new AuthorWithBookVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(x => x.Book.Title).ToList()
            }).FirstOrDefault();

            return _AuthorWithBookVM;
        }

        public Author UpdateAuthorById(int authorid, AuthorVM author)
        {
            var _author = _context.Authors.FirstOrDefault(x => x.Id.Equals(authorid));
            if (_author != null)
            {
                _author.FullName = author.FullName;

                _context.SaveChanges();
            }

            return _author;
        }

        public void DeleteAuthorById(int authorid)
        {
            var _author = _context.Authors.FirstOrDefault(x => x.Id.Equals(authorid));
            if (_author != null)
            {
                _context.Remove(_author);
                _context.SaveChanges();
            }
        }
    }
}
