namespace TaskDotNet.Web.Areas.Administration.Controllers
{
    using TaskDotNet.Common;
    using TaskDotNet.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
