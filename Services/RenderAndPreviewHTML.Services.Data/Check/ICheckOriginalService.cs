namespace RenderAndPreviewHTML.Services.Data.Check
{
    using System.Threading.Tasks;

    public interface ICheckOriginalService
    {
        Task<bool> HasSameRecordAsync(string content);
    }
}
