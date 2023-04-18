using NoteTaking.Data.Common.Repositories.IRepositories;
using NoteTaking.Data.Models;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Services.Interfaces
{
    public interface INoteService : INoteRepository
    {
        /// <summary>
        /// Get a note
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>A note mapped to T view model</returns>
        T GetNoteViewModel<T>(int? id);

        List<DetailsNoteViewModel> GetNotesAsDetailed(ApplicationUser user);

        /// <summary>
        /// Projects notes to NoteAllViewModel
        /// </summary>
        /// <param name="notes"></param>
        /// <returns>List of notes</returns>
        List<NoteAllViewModel> ProjectNotesForPrint(List<Note> notes);

        /// <summary>
        /// Search a note by it's title.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="avalableNotes"></param>
        /// <returns></returns>
        List<NoteAllViewModel> SearchNotesByTitle(string? value, IList<Note> notes);

        /// <summary>
        /// Sorts the application user's notes by sort contition.
        /// </summary>
        /// <param name="sortOption"></param>
        /// <param name="notes"></param>
        List<NoteAllViewModel> Sort(string sortOption, List<NoteAllViewModel> notes);
    }
}
