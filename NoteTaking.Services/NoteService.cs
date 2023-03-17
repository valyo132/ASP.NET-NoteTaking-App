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

        IList<NoteAllViewModel> INoteService.ProjectNotes(IList<Note> notes)
        {
            return _context.Notes
                .ProjectTo<NoteAllViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
