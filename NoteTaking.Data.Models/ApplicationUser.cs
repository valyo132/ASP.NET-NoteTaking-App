using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NoteTaking.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// First name.
        /// </summary>
        [Required]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Last name.
        /// </summary>
        [Required]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Personal notes.
        /// </summary>
        public ICollection<Note> Notes { get; set; } = new HashSet<Note>();

        /// <summary>
        /// Profile picture.
        /// </summary>
        public string ProfileImageURL { get; set; }
    }
}
