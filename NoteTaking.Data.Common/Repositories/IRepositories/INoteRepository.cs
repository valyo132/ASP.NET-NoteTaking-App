using NoteTaking.Data.Models;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Data.Common.Repositories.IRepositories
{
    public interface INoteRepository
    {
        void Create(NoteInputViewModel obj);

        void Delete(int? id);

        void DeletePermanently(int? id);

        void Edit(EditNoteInputViewModel obj);

        void Restore(int? id);

        IList<Note> GetAllNotes();
        IList<Note> GetAllDeletedNotes();
    }
}
