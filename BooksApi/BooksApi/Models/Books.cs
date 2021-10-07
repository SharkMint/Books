using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Expcert { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }
    }
}
