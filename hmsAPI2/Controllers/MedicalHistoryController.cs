using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hmsAPI2.Controllers
{
    public class MedicalHistoryController : Controller
    {
        // GET: MedicalHistoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MedicalHistoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicalHistoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalHistoryController/Create
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

        // GET: MedicalHistoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicalHistoryController/Edit/5
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

        // GET: MedicalHistoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicalHistoryController/Delete/5
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
