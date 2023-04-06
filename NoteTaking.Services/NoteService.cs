using AutoMapper;
using NoteTaking.Data;
using NoteTaking.Data.Common.Repositories;
using NoteTaking.Data.Models;
using NoteTaking.Services.Interfaces;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Services
{
    public class NoteService : NoteRepository, INoteService
    {
        private readonly IMapper _mapper;
        private readonly NoteTakingContext _context;

        public NoteService(IMapper mapper, NoteTakingContext context) : base(mapper, context)
        {
            _mapper = mapper;
            _context = context;
        }

        public T GetNoteViewModel<T>(int? id)
        {
            var obj = _context.Notes.Find(id);
            var noteViewModel = _mapper.Map<T>(obj);
            return noteViewModel;
        }

        public List<NoteAllViewModel> ProjectNotesForPrint(List<Note> notes)
        {
            List<NoteAllViewModel> notesToPrint = new List<NoteAllViewModel>();

            foreach (var note in notes)
            {
                NoteAllViewModel noteToPrint = new NoteAllViewModel()
                {
                    Title = note.Title,
                    Date = note.Date,
                    Id = note.Id
                };

                notesToPrint.Add(noteToPrint);
            }

            return notesToPrint;
        }

        public List<NoteAllViewModel> SearchNotesByTitle(string? value)
        {
            var notes = _context.Notes
                .Where(n => n.Title.ToLower().Contains(value.ToLower()) && n.IsDeleted == false)
                .ToList();

            return ProjectNotesForPrint(notes);
        }

        public List<NoteAllViewModel> Sort(string sortOption, List<NoteAllViewModel> notes)
        {
            if (sortOption == "Latest")
            {
                return notes
                    .AsEnumerable()
                    .OrderByDescending(n => n.Date)
                    .ToList();
            }
            else if (sortOption == "Oldest")
            {
                return notes
                    .AsEnumerable()
                    .OrderBy(n => n.Date)
                    .ToList();
            }
            else if (sortOption == "Title")
            {
                return notes
                    .AsEnumerable()
                    .OrderBy(n => n.Title)
                    .ToList();
            }
            else
            {
                return notes;
            }
        }
    }
}
