using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyCompany.BuildCore.Controllers;

namespace MyCompany.BuildCore.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : BuildCoreControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
