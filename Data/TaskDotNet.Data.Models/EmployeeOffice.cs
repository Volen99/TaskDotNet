namespace TaskDotNet.Data.Models
{
    public class EmployeeOffice
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
