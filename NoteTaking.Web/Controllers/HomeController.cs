using Microsoft.AspNetCore.Mvc;
using NoteTaking.Services.Interfaces;
using NoteTaking.Web.Common;
using NoteTaking.Web.Models;
using NoteTaking.Web.ViewModels;
using System.Diagnostics;

namespace NoteTaking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteService _noteService;

        public HomeController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(NoteInputViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _noteService.Create(obj);
                TempData["success"] = "The note has been created!";

                return RedirectToAction("Index", "Home");
            }

            return View(obj);
        }

        public IActionResult All(string? sortOption)
        {
            var allNotes = _noteService.GetAllNotes();

            if (sortOption != null && sortOption != "None")
                SelectSortBoxInput._sortOption = sortOption;

            allNotes = _noteService.Sort(SelectSortBoxInput._sortOption, allNotes.ToList());

            var notesToPrint = _noteService.ProjectNotesForPrint(allNotes.ToList());

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}