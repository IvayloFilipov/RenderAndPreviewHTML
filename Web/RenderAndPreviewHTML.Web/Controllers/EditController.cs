namespace RenderAndPreviewHTML.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RenderAndPreviewHTML.Services.Data.Check;
    using RenderAndPreviewHTML.Services.Data.Edit;

    public class EditController : BaseController
    {
        private readonly IGetAllRecordsService getAllRecordsService;
        private readonly ICheckOriginalService checkOriginalService;

        public EditController(IGetAllRecordsService getAllRecordsService, ICheckOriginalService checkOriginalService)
        {
            this.getAllRecordsService = getAllRecordsService;
            this.checkOriginalService = checkOriginalService;
        }

        public async Task<IActionResult> ShowAllHtmls()
        {
            var allHtml = await this.getAllRecordsService.ShowAllHtmlRecordsAsynk();

            return this.View(allHtml);
        }

        // Does not work
        public async Task<IActionResult> CheckOriginal(string content)
        {
            var htmlToCompare = await this.checkOriginalService.HasSameRecordAsync(content);

            // var messageHasRecord = "The Html already exists into the DB!";
            var messageHasRecord = this.TempData["The Html already exists into the DB!"];

            // var messageIsUnique = "The Html is unique!";
            var messageIsUnique = this.TempData["The Html is unique!"];

            if (htmlToCompare == true)
            {
                return (IActionResult)messageHasRecord;
            }

            return (IActionResult)messageIsUnique;
        }
    }
}
