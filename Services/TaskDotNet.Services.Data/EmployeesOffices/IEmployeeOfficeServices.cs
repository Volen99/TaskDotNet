namespace TaskDotNet.Services.Data.EmployeesOffices
{
    using System.Threading.Tasks;

    public interface IEmployeeOfficeServices
    {
        Task CreateAsync(int employeeId, int officeId);
    }
}
