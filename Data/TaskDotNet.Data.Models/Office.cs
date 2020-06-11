namespace TaskDotNet.Data.Models
{
    using System.Collections.Generic;

    using TaskDotNet.Data.Common.Models;

    public class Office : BaseDeletableModel<int>, IAuditInfo
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public bool IsHeadquarters { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<EmployeeOffice> EmployeesOffices { get; set; }
    }
}
