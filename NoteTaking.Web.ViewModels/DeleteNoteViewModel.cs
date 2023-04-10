namespace NoteTaking.Web.ViewModels
{

    /// <summary>
    /// Deleted note view model.
    /// </summary>
    public class DeleteNoteViewModel
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
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
