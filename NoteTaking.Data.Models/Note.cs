using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteTaking.Data.Models
{
    public class Note
    {
        /// <summary>
        /// ID.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Title.
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
        /// Is the note delete.
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Date of creating.
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        /// Application user
        /// </summary>
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}