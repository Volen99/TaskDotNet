namespace TaskDotNet.Services.Data.EmployeesOffices
{
    using System.Linq;
    using System.Threading.Tasks;

    using TaskDotNet.Data.Common.Repositories;
    using TaskDotNet.Data.Models;

    public class EmployeeOfficeServices : IEmployeeOfficeServices
    {
        private IRepository<EmployeeOffice> employeesOfficesRepository;

        public EmployeeOfficeServices(IRepository<EmployeeOffice> employeesOfficesRepository)
        {
            this.employeesOfficesRepository = employeesOfficesRepository;
        }

        public async Task CreateAsync(int employeeId, int officeId)
        {
            var doesExit = this.employeesOfficesRepository.All().Any(eo => eo.OfficeId == officeId);
            if (doesExit)
            {
                return;
            }

            var employeeOfficeNew = new EmployeeOffice
            {
                EmployeeId = employeeId,
                OfficeId = officeId,
            };

            await this.employeesOfficesRepository.AddAsync(employeeOfficeNew);
            await this.employeesOfficesRepository.SaveChangesAsync();
        }
    }
}
