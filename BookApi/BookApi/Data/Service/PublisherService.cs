using BookApi.Data.Model;
using BookApi.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data.Service
{
    public class PublisherService
    {
        private readonly AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        // Post - Publisher
        public void AddAuthor(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publisher.Add(_publisher);
            _context.SaveChanges();
        }

        // Get - PublisherAll
        public List<PublisherWithBooksAndAuthorsVM> GetPublisherDataAll()
        {
            var _PublisherWithBooksAndAuthorsVM = _context.Publisher.Select(x => new PublisherWithBooksAndAuthorsVM()
            {
                Name = x.Name,
                BookAuthorVMs = x.Books.Select(n => new BookAuthorVM()
                {
                    BookName = n.Title,
                    BookAuthor = n.Book_Authors.Select(x => x.Author.FullName).ToList()
                }).ToList()
            }).ToList();

            return _PublisherWithBooksAndAuthorsVM;
        }

        // Get - Publisher{id}
        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherid)
        {
            var _PublisherWithBooksAndAuthorsVM = _context.Publisher.Where(x => x.Id == publisherid).Select(x => new PublisherWithBooksAndAuthorsVM()
            {
                Name = x.Name,
                BookAuthorVMs = x.Books.Select(n => new BookAuthorVM()
                {
                    BookName = n.Title,
                    BookAuthor = n.Book_Authors.Select(x => x.Author.FullName).ToList()
                }).ToList()
            }).FirstOrDefault();

            return _PublisherWithBooksAndAuthorsVM;
        }

        // Put - Publisher
        public Publisher UpdatePublisherById(int id,  PublisherVM publisher)
        {
            var _publisher = _context.Publisher.FirstOrDefault(x => x.Id.Equals(id));
            if(_publisher != null)
            {
                _publisher.Name = publisher.Name;

                _context.SaveChanges();
            }

            return _publisher;
        }


        // Delete - Publisher
        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publisher.FirstOrDefault(x => x.Id == id);

            if(_publisher != null)
            {
                _context.Publisher.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
