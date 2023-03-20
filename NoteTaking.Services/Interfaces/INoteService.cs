using NoteTaking.Data.Models;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Services.Interfaces
{
    public interface INoteService
    {
        void Create(NoteInputViewModel obj);

        void Delete(int? id);

        void Edit(EditNoteInputViewModel obj);

        List<Note> Sort(string sortOption, List<Note> notes);

        T GetNoteViewModel<T>(int? id);

        IList<Note> GetAllNotes();

        List<NoteAllViewModel> ProjectNotesForPrint(List<Note> notes);

    }
}
