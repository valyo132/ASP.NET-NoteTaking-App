using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteTaking.Data.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Title must contain at least 1 charachter")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Body text must be at least one charachter long")]
        public string Text { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}