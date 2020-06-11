namespace TaskDotNet.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TaskDotNet.Data.Common.Models;
    using TaskDotNet.Data.Models.Enums;

    public class Employee : BaseDeletableModel<int>, IAuditInfo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public int VacationDays { get; set; }

        public ExpirenceLevel ExpirenceLevel { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<EmployeeOffice> EmployeesOffices { get; set; }
    }
}
