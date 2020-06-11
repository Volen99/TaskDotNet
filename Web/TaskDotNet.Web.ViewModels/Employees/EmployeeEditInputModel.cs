namespace TaskDotNet.Web.ViewModels.Employees
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TaskDotNet.Data.Models;
    using TaskDotNet.Data.Models.Enums;
    using TaskDotNet.Services.Mapping;

    public class EmployeeEditInputModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        [Display(Name = "Vacation Days")]
        public int VacationDays { get; set; }

        [Display(Name = "Expirence Level")]
        public ExpirenceLevel ExpirenceLevel { get; set; }

        public int CompanyId { get; set; }

        public IEnumerable<OfficeDropDownViewModel> OfficesDropDown { get; set; }

        public List<int> Offices { get; set; }
    }
}
