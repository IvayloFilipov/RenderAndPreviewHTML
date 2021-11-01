namespace RenderAndPreviewHTML.Services.Data.Edit
{
    using System.Threading.Tasks;

    using RenderAndPreviewHTML.Web.ViewModels.Edit;

    public interface IEditHtmlService
    {
        Task<EditViewModel> SelectedHtmlAsync(int htmlId);

        Task EditHtmlAsync(int htmlId, string content);
    }
}
