namespace RenderAndPreviewHTML.Services.Data.Save
{
    using System.Threading.Tasks;

    public interface ISaveService
    {
        Task<int> SaveHtmlAsync(string content);

        Task UpdateHtmlAsync(int id, string content);
    }
}
