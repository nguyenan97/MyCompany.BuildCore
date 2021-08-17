using System.Threading.Tasks;
using MyCompany.BuildCore.Models.TokenAuth;
using MyCompany.BuildCore.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyCompany.BuildCore.Web.Tests.Controllers
{
    public class HomeController_Tests: BuildCoreWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}