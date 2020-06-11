namespace TaskDotNet.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using TaskDotNet.Services.Data.Companies;
    using TaskDotNet.Services.Data.Employees;
    using TaskDotNet.Services.Data.EmployeesOffices;
    using TaskDotNet.Services.Data.Offices;
    using TaskDotNet.Web.ViewModels.Companies;
    using TaskDotNet.Web.ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IEmployeesService employeesService;
        private readonly ICompaniesService companiesService;
        private readonly IEmployeeOfficeServices employeeOfficeServices;
        private readonly IOfficesService officesService;

        public EmployeesController(
            IEmployeesService employeesService,
            ICompaniesService companiesService,
            IEmployeeOfficeServices employeeOfficeServices,
            IOfficesService officesService)
        {
            this.employeesService = employeesService;
            this.companiesService = companiesService;
            this.employeeOfficeServices = employeeOfficeServices;
            this.officesService = officesService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(int companyId)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View();
            }

            var officesCurrent = this.officesService.GetAllByCompanyId<OfficeDropDownViewModel>(companyId);

            var viewModel = new EmployeeCreateInputModel
            {
                CompanyId = companyId,
                OfficesDropDown = officesCurrent,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateInputModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View();
            }

            var employeeId = await this.employeesService.CreateAsync(input.FirstName, input.LastName, input.Salary, input.VacationDays, input.ExpirenceLevel, input.CompanyId);

            if (input.Offices != null)
            {
                for (int i = 0; i < input.Offices.Count; i++)
                {
                    await this.employeeOfficeServices.CreateAsync(employeeId, input.Offices[i]);
                }
            }

            var companyCurrent = this.companiesService.GetById<CompanyViewModel>(input.CompanyId);

            this.TempData["InfoMessage"] = "Employee successfully created!";
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

            var employeeCurrent = this.employeesService.GetById<EmployeeEditInputModel>(id);

            var officesCurrent = this.officesService.GetAllByCompanyId<OfficeDropDownViewModel>(employeeCurrent.CompanyId);

            employeeCurrent.OfficesDropDown = officesCurrent;

            return this.View(employeeCurrent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeEditInputModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            if (input.Offices != null)
            {
                for (int i = 0; i < input.Offices.Count; i++)
                {
                    await this.employeeOfficeServices.CreateAsync(input.Id, input.Offices[i]);
                }
            }

            await this.employeesService.Edit(input.Id, input.FirstName, input.LastName, input.Salary, input.VacationDays, (int)input.ExpirenceLevel);

            var companyNameCurrent = this.companiesService.GetById<CompanyViewModel>(input.CompanyId).Name;

            this.TempData["InfoMessage"] = "Employee successfully edited!";
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

            var employeeCurrent = this.employeesService.GetById<EmployeeDeleteInputModel>(id);

            return this.View(employeeCurrent);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(EmployeeDeleteInputModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            var companyNameCurrent = this.companiesService.GetById<CompanyViewModel>(input.CompanyId).Name;

            await this.employeesService.Delete(input.Id);

            this.TempData["InfoMessage"] = "Employee successfully deleted!";
            return this.RedirectToRoute("TaskDotNetCompany", new { name = companyNameCurrent });
        }
    }
}
