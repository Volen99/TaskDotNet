namespace TaskDotNet.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using TaskDotNet.Services.Data.Companies;
    using TaskDotNet.Services.Data.Offices;
    using TaskDotNet.Web.ViewModels.Companies;
    using TaskDotNet.Web.ViewModels.Offices;

    public class OfficesController : Controller
    {
        private readonly IOfficesService officesService;
        private readonly ICompaniesService companiesService;

        public OfficesController(IOfficesService officesService, ICompaniesService companiesService)
        {
            this.officesService = officesService;
            this.companiesService = companiesService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(int companyId)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View();
            }

            var viewModel = new OfficeCreateInputModel
            {
                CompanyId = companyId,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OfficeCreateInputModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View();
            }

            await this.officesService.CreateAsync(input.Country, input.City, input.Street, input.StreetNumber, input.IsHeadquarters, input.CompanyId);

            var companyCurrent = this.companiesService.GetById<CompanyViewModel>(input.CompanyId);

            this.TempData["InfoMessage"] = "Office successfully created!";
            return this.RedirectToRoute("TaskDotNetCompany", new { name = companyCurrent.Name });
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View();
            }

            var officeCurrent = this.officesService.GetById<OfficeEditInputViewModel>(id);

            return this.View(officeCurrent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OfficeEditInputViewModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            await this.officesService.Edit(input.Id, input.Country, input.City, input.Street, input.StreetNumber, input.IsHeadquarters);

            var companyNameCurrent = this.companiesService.GetById<CompanyViewModel>(input.CompanyId).Name;

            this.TempData["InfoMessage"] = "Office successfully edited!";
            return this.RedirectToRoute("TaskDotNetCompany", new { name = companyNameCurrent });
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View();
            }

            var officeCurrent = this.officesService.GetById<OfficeDeleteInputModel>(id);

            return this.View(officeCurrent);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OfficeDeleteInputModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            var companyNameCurrent = this.companiesService.GetById<CompanyViewModel>(input.CompanyId).Name;

            await this.officesService.Delete(input.Id);

            this.TempData["InfoMessage"] = "office successfully deleted!";
            return this.RedirectToRoute("TaskDotNetCompany", new { name = companyNameCurrent });
        }
    }
}
