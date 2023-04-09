using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NoteTaking.Data.Models;
using NoteTaking.Services.Interfaces;
using NoteTaking.Web.Common;
using NoteTaking.Web.Models;
using NoteTaking.Web.ViewModels;
using System.Diagnostics;
using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;

namespace NoteTaking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IUserService _userService;

        public HomeController(INoteService noteService, IUserService userService)
        {
            _noteService = noteService;
            _userService = userService;
        }
        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
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
                //var allNotes = _noteService.GetAllNotes(user);
                notes = _noteService.ProjectNotesForPrint(allNotes.ToList());
            }

            if (sortOption != null && sortOption != "None")
                SelectSortBoxInput._sortOption = sortOption;

            notes = _noteService.Sort(SelectSortBoxInput._sortOption, notes.ToList());

            return View(notes);
        }

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

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            _noteService.Delete(id);
            TempData["success"] = "The note has been deleted!";

            return RedirectToAction("All", "Home");
        }

        public IActionResult DeletePermanently(int? id)
        {
            if (id == null)
                return NotFound();

            _noteService.DeletePermanently(id);
            TempData["success"] = "The note has been deleted!";

            return RedirectToAction("AllDeletedNotes", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _noteService.GetNoteViewModel<EditNoteInputViewModel>(id);
            return View(obj);
        }

        [HttpPost]
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

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _noteService.GetNoteViewModel<DetailsNoteViewModel>(id);

            return View(obj);
        }

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private ApplicationUser GetCurrentUser()
        {
            var userId = User.Identity.GetUserId();
            return _userService.GetUserById(userId);
        }
    }
}