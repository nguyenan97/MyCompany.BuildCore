using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyCompany.BuildCore.Controllers;

namespace MyCompany.BuildCore.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : BuildCoreControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
