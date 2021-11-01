namespace RenderAndPreviewHTML.Services.Data.Check
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RenderAndPreviewHTML.Data;

    public class CheckOriginalService : ICheckOriginalService
    {
        private readonly ApplicationDbContext dbContext;

        public CheckOriginalService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> HasSameRecordAsync(string content)
        {
            var currHtml = await this.dbContext
                .ExampleHtmls
                .Where(x => x.Content == content)
                .FirstOrDefaultAsync();

            if (currHtml == null)
            {
                return false;
            }

            return true;
        }
    }
}
