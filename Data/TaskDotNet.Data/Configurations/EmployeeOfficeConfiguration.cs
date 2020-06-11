namespace TaskDotNet.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using TaskDotNet.Data.Models;

    public class EmployeeOfficeConfiguration : IEntityTypeConfiguration<EmployeeOffice>
    {
        public void Configure(EntityTypeBuilder<EmployeeOffice> builder)
        {
            builder
               .HasKey(eo => new { eo.EmployeeId, eo.OfficeId });

            builder
                .HasOne(e => e.Employee)
                .WithMany(e => e.EmployeesOffices)
                .HasForeignKey(e => e.EmployeeId);

            builder
                .HasOne(o => o.Office)
                .WithMany(o => o.EmployeesOffices)
                .HasForeignKey(o => o.OfficeId);
        }
    }
}
