namespace RenderAndPreviewHTML.Data.Models.ExampleHTML
{
    using System.ComponentModel.DataAnnotations;

    using RenderAndPreviewHTML.Data.Common.Models;

    using static RenderAndPreviewHTML.Common.GlobalConstants;

    public class ExampleHtml : BaseModel<int>
    {
        [Required]
        [MaxLength(MaxSize5MB)]
        public string Content { get; set; }
    }
}
