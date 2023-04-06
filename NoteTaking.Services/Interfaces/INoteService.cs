using NoteTaking.Data.Common.Repositories.IRepositories;
using NoteTaking.Data.Models;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Services.Interfaces
{
    public interface INoteService : INoteRepository
    {
        List<NoteAllViewModel> Sort(string sortOption, List<NoteAllViewModel> notes);

        T GetNoteViewModel<T>(int? id);

        List<NoteAllViewModel> ProjectNotesForPrint(List<Note> notes);

        List<NoteAllViewModel> SearchNotesByTitle(string? value);
    }
}
