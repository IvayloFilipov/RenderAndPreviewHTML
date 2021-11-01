namespace RenderAndPreviewHTML.Web.ViewModels.Edit
{
    using System;

    public class EditViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
