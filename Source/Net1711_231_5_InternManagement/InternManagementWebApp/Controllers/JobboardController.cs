using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternManagementWebApp.Controllers
{
    public class JobboardController : Controller
    {
        // GET: JobboardController
        public ActionResult Index()
        {
            return View();
        }

        // GET: JobboardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobboardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobboardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobboardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobboardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobboardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobboardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
