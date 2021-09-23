using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public class JqueryDatatableRequest
    {
        public class Column
        {
            public string data { get; set; }
            public string name { get; set; }
            public bool searchable { get; set; }
            public bool orderable { get; set; }
            public Search search { get; set; }
        }

        public class Search
        {
            public string value { get; set; }
            public string regex { get; set; }
        }

        public class Order
        {
            public int column { get; set; }
            public string dir { get; set; }
        }

        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public List<Column> Columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }

        public PageResultRequest MapRequest()
        {
            var request = new PageResultRequest();
            request.PageSize = this.Length;
            request.PageIndex = (Start / Length) + 1;

            for (int i = 0; i < Columns.Count; i++)
            {
                var column = Columns[i];

                if (column.search != null && !string.IsNullOrEmpty(column.search.value))
                {
                    request.Filters.Add(new PageResultRequest.Filter()
                    {
                        Key = FirstCharToUpper(column.data),
                        Value = column.search.value,
                        Type = PageResultRequest.FilterType.LIKE
                    });
                }
            }

            if (order != null)
            {
                foreach (var entity in order)
                {
                    if (entity.column > Columns.Count)
                        continue;

                    request.Sorts.Add(new PageResultRequest.Sort()
                    {
                        Key = FirstCharToUpper(Columns[entity.column].data),
                        OrderBy = entity.dir
                    });
                }
            }

            return request;
        }

        private string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                return input;

            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }
    }
}
