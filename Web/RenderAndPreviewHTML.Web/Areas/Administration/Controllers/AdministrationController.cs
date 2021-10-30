namespace RenderAndPreviewHTML.Web.Areas.Administration.Controllers
{
    using RenderAndPreviewHTML.Common;
    using RenderAndPreviewHTML.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
