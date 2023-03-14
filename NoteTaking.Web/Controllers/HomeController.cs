using Microsoft.AspNetCore.Mvc;
using NoteTaking.Services.Interfaces;
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

                return RedirectToAction("All", "Home");
            }

            return View(obj);
        }

        public IActionResult All()
        {
            var allNotes = _noteService.GetAllNotes();
            var notesToPrint = _noteService.ProjectNotes(allNotes);

            return View(notesToPrint);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            _noteService.Delete(id);

            return RedirectToAction("All", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _noteService.GetNoteViewModel(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(EditNoteInputViewModel note)
        {
            if (ModelState.IsValid)
            {
                _noteService.Edit(note);
                return RedirectToAction("All", "Home");
            }

            return View(note);
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