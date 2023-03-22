using AutoMapper;
using AutoMapper.QueryableExtensions;
using NoteTaking.Data;
using NoteTaking.Data.Models;
using NoteTaking.Services.Interfaces;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Services
{
    public class NoteService : INoteService
    {
        private readonly IMapper _mapper;
        private readonly NoteTakingContext _context;

        public NoteService(IMapper mapper, NoteTakingContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Create(NoteInputViewModel obj)
        {
            Note note = _mapper.Map<Note>(obj);
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            Note note = _context.Notes.Find(id);
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public void Edit(EditNoteInputViewModel obj)
        {
            var note = _context.Notes.Find(obj.Id);
            note.Title = obj.Title;
            note.Text = obj.Text;
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        public IList<Note> GetAllNotes()
            => _context.Notes.ToList();

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

        public List<Note> Sort(string sortOption, List<Note> notes)
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
