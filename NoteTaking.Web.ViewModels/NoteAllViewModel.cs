namespace NoteTaking.Web.ViewModels
{
    /// <summary>
    /// Note view model
    /// </summary>
    public class NoteAllViewModel
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
        /// Date
        /// </summary>
        public DateTime Date { get; set; }
    }
}
