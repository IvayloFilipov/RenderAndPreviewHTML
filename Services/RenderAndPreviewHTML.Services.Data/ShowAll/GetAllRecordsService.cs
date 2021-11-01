namespace RenderAndPreviewHTML.Services.Data.Edit
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RenderAndPreviewHTML.Data;
    using RenderAndPreviewHTML.Web.ViewModels.Edit;

    public class GetAllRecordsService : IGetAllRecordsService
    {
        private readonly ApplicationDbContext dbContext;

        public GetAllRecordsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<EditViewModel>> ShowAllHtmlRecordsAsynk()
        {
            var htmls = await this.dbContext
                .ExampleHtmls
                .Select(x => new EditViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                })
                .ToListAsync();

            return htmls;
        }
    }
}
