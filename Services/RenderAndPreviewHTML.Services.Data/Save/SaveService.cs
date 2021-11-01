namespace RenderAndPreviewHTML.Services.Data.Save
{
    using System;
    using System.Threading.Tasks;

    using RenderAndPreviewHTML.Data;
    using RenderAndPreviewHTML.Data.Models.ExampleHTML;

    public class SaveService : ISaveService
    {
        private readonly ApplicationDbContext dbContext;

        public SaveService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> SaveHtmlAsync(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("Html was null or empty", nameof(content));
            }

            var html = new ExampleHtml()
            {
                Content = content,
            };

            await this.dbContext.ExampleHtmls.AddAsync(html);

            await this.dbContext.SaveChangesAsync();

            return html.Id;
        }

        public async Task UpdateHtmlAsync(int id, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("Html was null or empty", nameof(content));
            }

            var existing = await this.dbContext.ExampleHtmls.FindAsync(id);
            if (existing is null)
            {
                throw new ArgumentException("Invalid Id", nameof(id));
            }

            existing.Content = content;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
