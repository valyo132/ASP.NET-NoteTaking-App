using NoteTaking.Data.Models;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Data.Common.Repositories.IRepositories
{
    public interface INoteRepository
    {
        /// <summary>
        /// Creates the note for the current user.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="user"></param>
        void Create(NoteInputViewModel obj, ApplicationUser user);

        /// <summary>
        /// Deletes the note of the current user.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int? id);

        /// <summary>
        /// Deletes the note from the database of the current user.
        /// </summary>
        /// <param name="id"></param>
        void DeletePermanently(int? id);

        /// <summary>
        /// Edits the note of the current user.
        /// </summary>
        /// <param name="obj"></param>
        void Edit(EditNoteInputViewModel obj);

        /// <summary>
        /// Restores from deleted the note of the current user.
        /// </summary>
        /// <param name="id"></param>
        void Restore(int? id);

        /// <summary>
        /// Gets all deleted notes of the current user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        IList<Note> GetAllDeletedNotes(ApplicationUser user);

        /// <summary>
        /// Gets all not deleted notes of the current user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        IList<Note> GetAllNotes(ApplicationUser user);

        /// <summary>
        /// Get note by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Note</returns>
        Note GetNote(int id);
    }
}
