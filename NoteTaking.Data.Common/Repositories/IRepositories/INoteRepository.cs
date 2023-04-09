using NoteTaking.Data.Models;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Data.Common.Repositories.IRepositories
{
    public interface INoteRepository
    {
        void Create(NoteInputViewModel obj, ApplicationUser user);

        void Delete(int? id);

        void DeletePermanently(int? id);

        void Edit(EditNoteInputViewModel obj);

        void Restore(int? id);

        IList<Note> GetAllNotes(ApplicationUser user);
        IList<Note> GetAllDeletedNotes(ApplicationUser user);
    }
}
