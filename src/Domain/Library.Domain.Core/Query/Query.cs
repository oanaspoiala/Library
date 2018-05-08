using System.Collections.Generic;

namespace Library.Domain.Core.Query
{
    public class Query
    {
        public Query()
        {
            Filters = new List<QueryFilterItem>();
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public QuerySortItem Sort { get; set; }
        public List<QueryFilterItem> Filters { get; set; }
    }
}
