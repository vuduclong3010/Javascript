using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksAndAuthorsVM
    {
        public string Name { get; set; }

        public List<BookAuthorVM> BookAuthorVMs { get; set; }
    }

    public class BookAuthorVM
    {
        public string BookName { get; set; }

        public List<string> BookAuthor { get; set; }
    }
}
