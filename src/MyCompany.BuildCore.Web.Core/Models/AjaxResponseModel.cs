using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.BuildCore.Models
{
    public class AjaxResponseModel
    {
        public List<ClientAlert> Errors { get; set; }

        public List<ClientAlert> Warns { get; set; }

        public List<ClientAlert> Alerts { get; set; }

        public string ResultHtml { get; set; }
    }

    public class ClientAlert
    {
        public string Key { get; set; }

        public List<string> Messages { get; set; }
    }
}
