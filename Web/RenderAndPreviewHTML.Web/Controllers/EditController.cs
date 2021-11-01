namespace RenderAndPreviewHTML.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RenderAndPreviewHTML.Services.Data.Edit;

    public class EditController : BaseController
    {
        private readonly IGetAllRecordsService getAllRecordsService;

        public EditController(IGetAllRecordsService getAllRecordsService)
        {
            this.getAllRecordsService = getAllRecordsService;
        }

        public async Task<IActionResult> ShowAllHtmls()
        {
            var allHtml = await this.getAllRecordsService.ShowAllHtmlRecordsAsynk();

            return this.View(allHtml);
        }
    }
}
