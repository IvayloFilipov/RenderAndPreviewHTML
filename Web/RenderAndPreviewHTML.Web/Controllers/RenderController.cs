namespace RenderAndPreviewHTML.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RenderAndPreviewHTML.Services.Data.Save;
    using RenderAndPreviewHTML.Web.ViewModels.Render;

    public class RenderController : BaseController
    {
        private readonly ISaveService saveService;

        public RenderController(ISaveService saveService)
        {
            this.saveService = saveService;
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

            return this.RedirectToAction(nameof(Preview), new { id = htmlId });
        }

        public async Task<IActionResult> Preview(int id)
        {
            return this.View(nameof(CreateHtml), new RenderViewModel { Content = "asdasd", Id = id });
        }
    }
}
