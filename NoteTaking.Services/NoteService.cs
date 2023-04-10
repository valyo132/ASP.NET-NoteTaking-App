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
        /// <summary>
        /// An instance of AutoMapper.
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// An instance of NoteTakingContext.
        /// </summary>
        private readonly NoteTakingContext _context;

        public NoteService(IMapper mapper, NoteTakingContext context) : base(mapper, context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Get a note
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns>A note mapped to T view model</returns>
        public T GetNoteViewModel<T>(int? id)
        {
            var obj = _context.Notes.Find(id);
            var noteViewModel = _mapper.Map<T>(obj);
            return noteViewModel;
        }

        /// <summary>
        /// Projects notes to NoteAllViewModel
        /// </summary>
        /// <param name="notes"></param>
        /// <returns>List of notes</returns>
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

        /// <summary>
        /// Search a note by it's title.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="avalableNotes"></param>
        /// <returns></returns>
        public List<NoteAllViewModel> SearchNotesByTitle(string? value, IList<Note> avalableNotes)
        {
            var notes = avalableNotes
                .Where(n => n.Title.ToLower().Contains(value.ToLower()) && n.IsDeleted == false)
                .ToList();

            return ProjectNotesForPrint(notes);
        }

        /// <summary>
        /// Sorts the application user's notes by sort contition.
        /// </summary>
        /// <param name="sortOption"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
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
