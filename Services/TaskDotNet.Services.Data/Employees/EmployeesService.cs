namespace TaskDotNet.Services.Data.Employees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TaskDotNet.Data.Common.Repositories;
    using TaskDotNet.Data.Models;
    using TaskDotNet.Data.Models.Enums;
    using TaskDotNet.Services.Mapping;

    public class EmployeesService : IEmployeesService
    {
        private readonly IDeletableEntityRepository<Employee> employeesRepository;

        public EmployeesService(IDeletableEntityRepository<Employee> employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }

        public async Task<int> CreateAsync(string firstName, string lastName, decimal salary, int vacationDays, int expirenceLevel, int companyId)
        {
            var employeeNew = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                HireDate = DateTime.UtcNow,
                Salary = salary,
                VacationDays = vacationDays,
                ExpirenceLevel = (ExpirenceLevel)expirenceLevel,
                CompanyId = companyId,
            };

            await this.employeesRepository.AddAsync(employeeNew);
            await this.employeesRepository.SaveChangesAsync();

            return employeeNew.Id;
        }

        public T GetById<T>(int employeeId)
        {
            var employeeCurrent = this.employeesRepository.All()
                .Where(i => i.Id == employeeId)
                .To<T>()
                .FirstOrDefault();

            return employeeCurrent;
        }

        public IEnumerable<T> GetByCompanyId<T>(int companyId, int? take = null, int skip = 0)
        {
            var employees = this.employeesRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.CompanyId == companyId)
                .Skip(skip);

            if (take.HasValue)
            {
                employees = employees.Take(take.Value);
            }

            return employees.To<T>()
                .ToList();
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            var employees = this.employeesRepository.All();

            if (count.HasValue)
            {
                employees = employees.Take(count.Value);
            }

            return employees.To<T>()
                .ToList();
        }

        public async Task Edit(int id, string firstName, string lastName, decimal salary, int vacationDays, int expirenceLevel)
        {
            var employeeCurrent = this.employeesRepository.All()
                .FirstOrDefault(e => e.Id == id);

            employeeCurrent.FirstName = firstName;
            employeeCurrent.LastName = lastName;
            employeeCurrent.Salary = salary;
            employeeCurrent.VacationDays = vacationDays;
            employeeCurrent.ExpirenceLevel = (ExpirenceLevel)expirenceLevel;

            await this.employeesRepository.SaveChangesAsync();
        }

        public async Task<int> Delete(int employeeId)
        {
            var employeeCurrent = this.employeesRepository.All()
                .FirstOrDefault(e => e.Id == employeeId);

            var deletedEmployeCompanyId = employeeCurrent.CompanyId;

            this.employeesRepository.Delete(employeeCurrent);

            await this.employeesRepository.SaveChangesAsync();

            return deletedEmployeCompanyId;
        }

        public async Task DeleteAllByCompanyId(int companyId, int? count = null)
        {
            var companyEmployees = this.employeesRepository.All()
                .Where(e => e.CompanyId == companyId);

            foreach (var employee in companyEmployees)
            {
                this.employeesRepository.Delete(employee);
            }

            await this.employeesRepository.SaveChangesAsync();
        }

        public int GetCountByCompanyId(int companyId)
        {
            return this.employeesRepository.All()
                .Count(x => x.CompanyId == companyId);
        }
    }
}
