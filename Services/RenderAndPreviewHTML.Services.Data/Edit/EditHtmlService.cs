namespace RenderAndPreviewHTML.Services.Data.Edit
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RenderAndPreviewHTML.Data;
    using RenderAndPreviewHTML.Web.ViewModels.Edit;

    public class EditHtmlService : IEditHtmlService
    {
        private readonly ApplicationDbContext dbContext;

        public EditHtmlService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task EditHtmlAsync(int htmlId, string content)
        {
            var currHtml = await this.dbContext
                .ExampleHtmls
                .FindAsync(htmlId);

            if (currHtml == null)
            {
                throw new System.ArgumentException($"Invalid htmlId ID={htmlId}!", nameof(htmlId));
            }

            currHtml.Content = content;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<EditViewModel> SelectedHtmlAsync(int htmlId)
        {
            var selectedHtml = await this.dbContext
                .ExampleHtmls
                .Select(x => new EditViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                })
                .FirstOrDefaultAsync(x => x.Id == htmlId);

            return selectedHtml;
        }
    }
}
