namespace RenderAndPreviewHTML.Services.Data.Edit
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using RenderAndPreviewHTML.Web.ViewModels.Edit;

    public interface IGetAllRecordsService
    {
        Task<IEnumerable<EditViewModel>> ShowAllHtmlRecordsAsynk();
    }
}
