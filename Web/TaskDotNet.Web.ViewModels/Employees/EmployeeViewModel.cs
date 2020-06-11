namespace TaskDotNet.Web.ViewModels.Employees
{
    using System;
    using System.Collections.Generic;

    using TaskDotNet.Data.Models;
    using TaskDotNet.Data.Models.Enums;
    using TaskDotNet.Services.Mapping;

    public class EmployeeViewModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public int VacationDays { get; set; }

        public ExpirenceLevel ExpirenceLevel { get; set; }

        public ICollection<EmployeeOffice> EmployeesOffices { get; set; }
    }
}
