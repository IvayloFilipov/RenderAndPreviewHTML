namespace RenderAndPreviewHTML.Services.Data.Check
{
    using System;
    using System.Threading.Tasks;

    public interface ICheckOriginalService
    {
        Task<bool> HasSameRecordAsync(string content);
    }
}
