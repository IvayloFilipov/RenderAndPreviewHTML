namespace RenderAndPreviewHTML.Web.ViewModels.Render
{
    using System.ComponentModel.DataAnnotations;

    using static RenderAndPreviewHTML.Common.GlobalConstants;

    public class RenderViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Plese insert your example HTML")]
        [StringLength(MaxNumberCharacters, ErrorMessage = ContentLenghtErrorMessage, MinimumLength = MinNumberCharacters)]
        [Display(Name = "Write down your HTML here!")]
        public string Content { get; set; }
    }
}
