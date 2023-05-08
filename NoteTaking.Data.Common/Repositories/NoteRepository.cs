using AutoMapper;
using NoteTaking.Data.Common.Repositories.IRepositories;
using NoteTaking.Data.Models;
using NoteTaking.Web.ViewModels;

namespace NoteTaking.Data.Common.Repositories
{
    public class NoteRepository : INoteRepository
    {
        /// <summary>
        /// An instance of AutoMapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// An instance of NoteTakingContext
        /// </summary>
        private readonly NoteTakingContext _context;

        public NoteRepository(IMapper mapper, NoteTakingContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Creates the note for the current user.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="user"></param>
        public void Create(NoteInputViewModel obj, ApplicationUser user)
        {
            Note note = _mapper.Map<Note>(obj);
            user.Notes.Add(note);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the note of the current user.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int? id)
        {
            Note note = _context.Notes.Find(id);
            note.IsDeleted = true;
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes the note from the database of the current user.
        /// </summary>
        /// <param name="id"></param>
        public void DeletePermanently(int? id)
        {
            Note noteToDelete = _context.Notes.Find(id);
            _context.Notes.Remove(noteToDelete);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edits the note of the current user.
        /// </summary>
        /// <param name="obj"></param>
        public void Edit(EditNoteInputViewModel obj)
        {
            var note = _context.Notes.Find(obj.Id);
            note.Title = obj.Title;
            note.Text = obj.Text;
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        /// <summary>
        /// Restores from deleted the note of the current user.
        /// </summary>
        /// <param name="id"></param>
        public void Restore(int? id)
        {
            var noteToRestore = _context.Notes.Find(id);
            noteToRestore.IsDeleted = false;
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all deleted notes of the current user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IList<Note> GetAllDeletedNotes(ApplicationUser user)
             => user.Notes.Where(n => n.IsDeleted == true).ToList();

        /// <summary>
        /// Gets all not deleted notes of the current user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public IList<Note> GetAllNotes(ApplicationUser user)
        {
            var usersNotes = user.Notes;
            return usersNotes.Where(n => n.IsDeleted == false).ToList();
        }

        /// <summary>
        /// Get note by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Note</returns>
        public Note GetNote(int id)
        {
            return _context.Notes.Find(id);
        }
    }
}
