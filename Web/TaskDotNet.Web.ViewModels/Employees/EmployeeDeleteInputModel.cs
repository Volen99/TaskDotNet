namespace TaskDotNet.Web.ViewModels.Employees
{
    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;

    public class EmployeeDeleteInputModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompanyId { get; set; }
    }
}
