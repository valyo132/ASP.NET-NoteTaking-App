namespace NoteTaking.Web.ViewModels
{
    /// <summary>
    /// Detailed note view movel.
    /// </summary>
    public class DetailsNoteViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; } = null!;

        /// <summary>
        /// Date
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Is note pinned.
        /// </summary>
        public bool isPinned { get; set; }
    }
}
