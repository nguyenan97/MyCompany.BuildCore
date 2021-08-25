using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.BuildCore.Web.Models
{
    public class SearchModel
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int SkipCount
        {
            get
            {
                return PageIndex * PageSize;
            }
        }

        public string SortBy { get; set; }

        public string SortDirection { get; set; }
    }
}
