using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteTaking.Data.Models;
using NoteTaking.Services.Interfaces;
using NoteTaking.Web.Common;
using NoteTaking.Web.Models;
using NoteTaking.Web.ViewModels;
using System.Diagnostics;

namespace NoteTaking.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// An instance of NoteService.
        /// </summary>
        private readonly INoteService _noteService;
        /// <summary>
        /// An instance of UserService.
        /// </summary>
        private readonly IUserService _userService;

        public HomeController(INoteService noteService, IUserService userService)
        {
            _noteService = noteService;
            _userService = userService;
        }

        /// <summary>
        /// Get the main page of the website.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get the home page when there is a logged in user.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin, Client")]
        public IActionResult HomePage()
        {
            return View();
        }

        /// <summary>
        /// Create the note for the current user.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, Client")]
        public IActionResult HomePage(NoteInputViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var user = GetCurrentUser();
                _noteService.Create(obj, user);
                TempData["success"] = "The note has been created!";

                return RedirectToAction("HomePage", "Home");
            }

            return View(obj);
        }


        /// <summary>
        /// Get all notes that the current user has.
        /// Sorts the user's note by the type of the sort input.
        /// </summary>
        /// <param name="sortOption"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, Client")]
        public IActionResult All(string? sortOption)
        {
            var notes = new List<NoteAllViewModel>();
            var user = GetCurrentUser();
            var allNotes = _noteService.GetAllNotes(user);

            if (SearchIndicator.isSearching)
            {
                string searchOperation = SearchIndicator.searchCondition;
                notes = _noteService.SearchNotesByTitle(searchOperation, allNotes);
            }
            else
            {
                notes = _noteService.ProjectNotesForPrint(allNotes.ToList());
            }

            if (sortOption != null && sortOption != "None")
                SelectSortBoxInput._sortOption = sortOption;

            notes = _noteService.Sort(SelectSortBoxInput._sortOption, notes.ToList());

            return View(notes);
        }

        /// <summary>
        /// Gets all of the user's deleted notes.
        /// Restore a note.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, Client")]
        public IActionResult AllDeletedNotes(int? id)
        {
            var user = GetCurrentUser();

            if (id != null)
            {
                _noteService.Restore(id);

                TempData["success"] = "The note has been restored!";
            }

            var deletedNotes = _noteService.GetAllDeletedNotes(user);
            var notesToPrint = _noteService.ProjectNotesForPrint(deletedNotes.ToList());

            return View(notesToPrint);
        }

        /// <summary>
        /// Remove a the user's note from the list and marks it as deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, Client")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            _noteService.Delete(id);
            TempData["success"] = "The note has been deleted!";

            return RedirectToAction("All", "Home");
        }

        /// <summary>
        /// Delete the note from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, Client")]
        public IActionResult DeletePermanently(int? id)
        {
            if (id == null)
                return NotFound();

            _noteService.DeletePermanently(id);
            TempData["success"] = "The note has been deleted!";

            return RedirectToAction("AllDeletedNotes", "Home");
        }

        /// <summary>
        /// Get the edit page of the note.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin, Client")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _noteService.GetNoteViewModel<EditNoteInputViewModel>(id);
            return View(obj);
        }

        /// <summary>
        /// Edit the title and the text of the note and save it in the database.
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin, Client")]
        public IActionResult Edit(EditNoteInputViewModel note)
        {
            if (ModelState.IsValid)
            {
                _noteService.Edit(note);
                TempData["success"] = "The note has been updated!";

                return RedirectToAction("All", "Home");
            }

            return View(note);
        }

        /// <summary>
        /// Get the details page of the user's note.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin, Client")]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _noteService.GetNoteViewModel<DetailsNoteViewModel>(id);

            return View(obj);
        }

        /// <summary>
        /// Search for notes that contains the user's input and displays them.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin, Client")]
        public IActionResult Search(string value, string? flag)
        {
            if (flag == "Show all")
            {
                SearchIndicator.isSearching = false;
                return RedirectToAction("All", "Home");
            }

            SearchIndicator.searchCondition = value;
            SearchIndicator.isSearching = true;

            return RedirectToAction("All", "Home");
        }

        /// <summary>
        /// Get the privacy page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Get the user's account that is currently logged in in the website.
        /// </summary>
        /// <returns></returns>
        private ApplicationUser GetCurrentUser()
        {
            var userId = User.Identity.GetUserId();
            return _userService.GetUserById(userId);
        }
    }
}