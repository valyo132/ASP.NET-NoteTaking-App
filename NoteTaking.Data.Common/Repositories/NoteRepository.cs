using AutoMapper;
using NoteTaking.Data.Common.Repositories.IRepositories;
using NoteTaking.Data.Models;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Data.Common.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly IMapper _mapper;
        private readonly NoteTakingContext _context;

        public NoteRepository(IMapper mapper, NoteTakingContext context)
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
    }
}
