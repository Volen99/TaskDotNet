namespace TaskDotNet.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexCompanyViewModel> Companies { get; set; }
    }
}
