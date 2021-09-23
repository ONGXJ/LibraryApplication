using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public class PageResultRequest
    {
        public enum FilterType
        {
            LIKE = 1,
            BETWEEN = 2,
            EQUAL = 3,
        }
        public class Filter
        {
            public string Key { get; set; }
            public string Value { get; set; }
            public FilterType Type { get; set; }
        }

        public class Sort
        {
            public string Key { get; set; }
            public string OrderBy { get; set; }
        }

        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
        public bool IsMultiSort { get; set; }
        public string Keywords { get; set; }
        public List<Filter> Filters { get; set; } = new List<Filter>();
        public List<Sort> Sorts { get; set; } = new List<Sort>();
    }
}
