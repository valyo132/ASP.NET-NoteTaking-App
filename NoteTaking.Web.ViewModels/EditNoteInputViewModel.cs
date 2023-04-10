using System.ComponentModel.DataAnnotations;

namespace NoteTaking.Web.ViewModels
{
    /// <summary>
    /// Edit note view model.
    /// </summary>
    public class EditNoteInputViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Title must contain at least 1 charachter")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Text
        /// </summary>
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Body text must be at least one charachter long")]
        public string Text { get; set; } = null!;
    }
}
