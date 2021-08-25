using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using MyCompany.BuildCore.Error;
using MyCompany.BuildCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyCompany.BuildCore.Controllers
{
    public abstract class BuildCoreControllerBase: AbpController
    {
        protected BuildCoreControllerBase()
        {
            LocalizationSourceName = BuildCoreConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected AjaxResponseModel AjaxResponseModel
        {
            get
            {
                if (!ModelState.IsValid)
                {
                    AjaxResponseModel errorResponseModel = new AjaxResponseModel();
                    errorResponseModel.Errors = new List<ClientAlert>();
                    foreach (var key in ModelState.Keys)
                    {
                        if (ModelState[key].Errors.Count > 0)
                        {
                            var ajaxError = new ClientAlert { Key = key };
                            ajaxError.Messages = ModelState[key].Errors.Select(err => key == ErrorCodes.ErrorException.ToString() ? err.ErrorMessage : (LocalizationSource.GetStringOrNull(err.ErrorMessage) == null ? err.ErrorMessage : L(err.ErrorMessage))).ToList();
                            errorResponseModel.Errors.Add(ajaxError);
                        }
                    }
                    return errorResponseModel;
                }
                return null;
            }
        }
    }
}
