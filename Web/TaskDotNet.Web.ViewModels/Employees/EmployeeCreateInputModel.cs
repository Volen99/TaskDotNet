namespace TaskDotNet.Web.ViewModels.Employees
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;

    public class EmployeeCreateInputModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        [Display(Name = "Vacation Days")]
        public int VacationDays { get; set; }

        [Display(Name = "Expirence Level")]
        public int ExpirenceLevel { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public List<int> Offices { get; set; }

        public IEnumerable<OfficeDropDownViewModel> OfficesDropDown { get; set; }
    }
}
