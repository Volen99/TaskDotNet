namespace TaskDotNet.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Data.Companies;
    using TaskDotNet.Services.Data.Employees;
    using TaskDotNet.Services.Data.Offices;
    using TaskDotNet.Web.ViewModels.Companies;
    using TaskDotNet.Web.ViewModels.Employees;
    using TaskDotNet.Web.ViewModels.Offices;

    public class CompaniesController : Controller
    {
        private const int ItemsPerPage = 6;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICompaniesService companiesService;
        private readonly IEmployeesService employeesService;
        private readonly IOfficesService officesService;

        public CompaniesController(
            UserManager<ApplicationUser> userManager,
            ICompaniesService companiesService,
            IEmployeesService employeesService,
            IOfficesService officesService)
        {
            this.userManager = userManager;
            this.companiesService = companiesService;
            this.employeesService = employeesService;
            this.officesService = officesService;
        }

        public async Task<IActionResult> ByName(string name, int page = 1)
        {
            var viewModel = this.companiesService.GetByName<CompanyViewModel>(name);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.Employees = this.employeesService.GetByCompanyId<EmployeeViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);
            viewModel.Offices = this.officesService.GetAllByCompanyId<OfficeViewModel>(viewModel.Id);

            var count = this.employeesService.GetCountByCompanyId(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            if (this.User.Identity.IsAuthenticated)
            {
                viewModel.HasCurrentUserRights = (await this.userManager.GetUserAsync(this.User)).Id == viewModel.UserId ||
                    this.User.IsInRole("Admin");
            }

            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyCreateInputModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            var userCurrentId = (await this.userManager.GetUserAsync(this.User)).Id;
            var companyId = await this.companiesService.CreateAsync(input.Name, input.ImageUrl, userCurrentId);

            await this.officesService.CreateAsync(input.OfficeCountry, input.OfficeCity, input.OfficeStreet, input.OfficeStreetNumber, input.OfficeIsHeadquarters, companyId);

            this.TempData["InfoMessage"] = "Company successfully created!";
            return this.RedirectToAction(nameof(this.ByName), new { name = input.Name });
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View();
            }

            var companyCurrent = this.companiesService.GetById<EditCompanyInputModel>(id);
            companyCurrent.CompanyId = id;

            return this.View(companyCurrent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCompanyInputModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            await this.companiesService.Edit(input.Name, input.ImageUrl, input.CompanyId);

            this.TempData["InfoMessage"] = "Company successfully edited!";
            return this.RedirectToRoute("TaskDotNetCompany", new { name = input.Name });
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View();
            }

            var companyCurrent = this.companiesService.GetById<DeleteCompanyViewModel>(id);

            return this.View(companyCurrent);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCompanyViewModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            await this.companiesService.Delete(input.Id);

            this.TempData["InfoMessage"] = "Company successfully deleted!";
            return this.RedirectToAction("Index", "Home");
        }
    }
}
