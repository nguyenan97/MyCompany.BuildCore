using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.BuildCore.Web.Views.Shared.Components.Paging
{
    public class PagingModel
    {
        public int CurrentPageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public string ItemClickJsFunc { get; set; }

        public string PageSizeHtmlId { get; set; }
    }
}
