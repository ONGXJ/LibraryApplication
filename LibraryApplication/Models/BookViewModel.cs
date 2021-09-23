using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public class Book : BaseViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public bool IsOutOfStock { get; set; }
        public int? CategoryId { get; set; }
        public List<Book> BookList { get; set; }
    }
}
