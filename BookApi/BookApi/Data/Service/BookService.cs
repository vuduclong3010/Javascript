using BookApi.Data.Model;
using BookApi.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data.Service
{
    public class BookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthor(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };

                _context.book_Authors.Add(_book_author);
                _context.SaveChanges();
            }

        }

        public List<BookWithAuthorVM> GetAllBooks()
        {
            var _bookWithAuthorVM = _context.Books.Select(book => new BookWithAuthorVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).ToList();

            return _bookWithAuthorVM;
        }

        public BookWithAuthorVM GetBookById(int bookid) 
        {
            var _bookWithAuthors = _context.Books.Where(x => x.Id == bookid).Select(book => new BookWithAuthorVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
        }

        public Book UpdateBookById(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id.Equals(bookid));
            if(book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _book.PublisherId = book.PublisherId;

                _context.Books.Update(_book);
                _context.SaveChanges();
            }

            return _book;
        }

        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id.Equals(bookid));
            if (_book != null)
            {
                _context.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
