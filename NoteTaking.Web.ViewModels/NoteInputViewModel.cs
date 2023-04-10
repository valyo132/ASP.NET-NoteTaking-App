using System.ComponentModel.DataAnnotations;

namespace NoteTaking.Web.ViewModels
{
    /// <summary>
    /// Note input view model
    /// </summary>
    public class NoteInputViewModel
    {
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

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;
    }
}