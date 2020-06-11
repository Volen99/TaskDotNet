namespace TaskDotNet.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TaskDotNet.Data.Common.Models;

    public class Company : BaseDeletableModel<int>, IAuditInfo
    {
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Office> Offices { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
