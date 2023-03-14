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
            var note = _context.Notes.Find(id);
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public IList<Note> GetAllNotes()
            => _context.Notes.ToList();

        IList<NoteAllViewModel> INoteService.ProjectNotes(IList<Note> notes)
        {
            return _context.Notes
                .ProjectTo<NoteAllViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
