using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MyCompany.BuildCore.Api_Internal.Student;
using MyCompany.BuildCore.Api_Internal.Student.Dto;
using MyCompany.BuildCore.Controllers;
using MyCompany.BuildCore.Error;
using MyCompany.BuildCore.Models;
using MyCompany.BuildCore.Web.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.BuildCore.Web.Controllers
{
    public class StudentController : BuildCoreControllerBase
    {
        private readonly IStudentAdminAppService _studentAdminAppService;

        public StudentController(IStudentAdminAppService studentAdminAppService)
        {
            _studentAdminAppService = studentAdminAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult SearchStudentList(int draw, int start, int length, string searchValue, string orderByCollumn, string orderDirection)
        //{
        //    try
        //    {
        //        var searchStudentRequestDto = new SearchStudentRequestDto()
        //        {
        //            Keyword = searchValue,
        //            MaxResultCount = length,
        //            SkipCount = start,
        //            SortBy = orderByCollumn,
        //            SortDirection = orderDirection
        //        };
        //        var temp = _studentAdminAppService.GetAll(searchStudentRequestDto);
        //        var userEntities = temp.Items;
        //        var countTotalRow = temp.TotalCount;

        //        return new JsonResult(new { draw, recordsTotal = countTotalRow, recordsFiltered = countTotalRow, data = userEntities });
        //    }
        //    catch (Exception e)
        //    {
        //        Console.Write(e.Message);
        //        return new JsonResult(new { status = false, error = "" });
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> SearchStudentList(SearchStudentListModel model)
        {
            try
            {
                var searchStudentRequestDto = new SearchStudentRequestDto
                {
                    Keyword = model.Keyword,
                    SkipCount = model.SkipCount,
                    MaxResultCount = model.PageSize,
                    SortBy = model.SortBy,
                    SortDirection = model.SortDirection
                };

                var searchStudentListResultModel = new SearchStudentListResultModel
                {
                    StudentDtoList = _studentAdminAppService.GetAll(searchStudentRequestDto),
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize
                };

                string resultHtml = await this.RenderViewToStringAsync("Partials/SearchStudentListResult", searchStudentListResultModel);
                return Json(new AjaxResponse { Success = true, Result = new AjaxResponseModel { ResultHtml = resultHtml } });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ErrorCodes.ErrorException.ToString(), ex.Message);
                return Json(new AjaxResponse { Success = true, Result = AjaxResponseModel });
            }
        }
    }
}
