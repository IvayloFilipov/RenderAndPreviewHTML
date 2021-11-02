namespace RenderAndPreviewHTML.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RenderAndPreviewHTML.Services.Data.Edit;
    using RenderAndPreviewHTML.Services.Data.Save;
    using RenderAndPreviewHTML.Web.ViewModels.Edit;
    using RenderAndPreviewHTML.Web.ViewModels.Render;

    public class RenderController : BaseController
    {
        private readonly ISaveService saveService;
        private readonly IEditHtmlService editHtmlService;
        private readonly IGetAllRecordsService getAllRecordsService;

        public RenderController(ISaveService saveService, IEditHtmlService editHtmlService, IGetAllRecordsService getAllRecordsService)
        {
            this.saveService = saveService;
            this.editHtmlService = editHtmlService;
            this.getAllRecordsService = getAllRecordsService;
        }

        public IActionResult CreateHtml()
        {
            return this.View();
        }

        public IActionResult ShowAllHtmls()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveHtmlAsync(RenderViewModel data)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(data);
            }

            var htmlId = data.Id;

            if (data.Id > 0)
            {
                // Handle Update
                await this.saveService.UpdateHtmlAsync(data.Id, data.Content);
            }
            else
            {
                // Create new entry
                htmlId = await this.saveService.SaveHtmlAsync(data.Content);
            }

            return this.RedirectToAction(nameof(this.EditSelectedHtml), new { id = htmlId });
        }

        public async Task<IActionResult> EditSelectedHtml(int id)
        {
            var selectedHtml = await this.editHtmlService.SelectedHtmlAsync(id);

            var htmlToEdit = new RenderViewModel
            {
                Id = selectedHtml.Id,
                Content = selectedHtml.Content,
            };

            return this.View(nameof(this.CreateHtml), htmlToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> EditSelectedHtml(EditViewModel currHtml)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(currHtml);
            }

            await this.saveService.SaveHtmlAsync(currHtml.Content);

            return this.RedirectToAction(nameof(this.ShowAllHtmls));
        }
    }
}
