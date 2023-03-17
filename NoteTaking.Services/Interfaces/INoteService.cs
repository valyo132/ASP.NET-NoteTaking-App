using NoteTaking.Data.Models;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Services.Interfaces
{
    public interface INoteService
    {
        void Create(NoteInputViewModel obj);

        void Delete(int? id);

        void Edit(EditNoteInputViewModel obj);

        T GetNoteViewModel<T>(int? id);

        IList<Note> GetAllNotes();

        IList<NoteAllViewModel> ProjectNotes(IList<Note> notes);
    }
}
