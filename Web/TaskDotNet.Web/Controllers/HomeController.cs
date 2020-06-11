namespace TaskDotNet.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using TaskDotNet.Web.ViewModels;
    using TaskDotNet.Services.Data.Companies;
    using TaskDotNet.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly ICompaniesService companiesServices;

        public HomeController(ICompaniesService companiesServices)
        {
            this.companiesServices = companiesServices;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Companies = this.companiesServices.GetAll<IndexCompanyViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
