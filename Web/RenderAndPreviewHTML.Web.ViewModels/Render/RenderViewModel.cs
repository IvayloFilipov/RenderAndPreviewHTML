namespace RenderAndPreviewHTML.Web.ViewModels.Render
{
    using System.ComponentModel.DataAnnotations;

    using static RenderAndPreviewHTML.Common.GlobalConstants;

    public class RenderViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Plese insert your example HTML above")]
        [StringLength(MaxNumberCharacters, ErrorMessage = ContentLenghtErrorMessage, MinimumLength = MinNumberCharacters)]
        public string Content { get; set; }
    }
}
