using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NASA.Models;
using NASA.Services;

namespace NASA.Controllers
{
    public class MisionController : Controller
    {
        private Service service;

        public MisionController() { this.service = new Service(); }
        // GET: MisionController
        public ActionResult Index()
        {
            var mision = service.mostrarMisiones();
            ViewBag.AstronautasMap = service.mostrarAstronautas()
       .ToDictionary(a => a.Cedula, a => a.Nombre);

            return View(mision);
        }

        // GET: MisionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MisionController/Create
        public ActionResult Create()
        {
            ViewBag.astronautas = service.mostrarAstronautas();
            ViewBag.naves = service.mostrarNaves().Where(n => n.Aceptabilidad).ToList();
            return View();
        }

        // POST: MisionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mision mision)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.agregarMision(mision);
                    return RedirectToAction("Index");
                }
                ViewBag.astronautas = service.mostrarAstronautas();
                ViewBag.naves = service.mostrarNaves().Where(n => n.Aceptabilidad).ToList();
                return View(mision);
            }
            catch
            {
                ViewBag.astronautas = service.mostrarAstronautas();
                ViewBag.naves = service.mostrarNaves().Where(n => n.Aceptabilidad).ToList();
                return View(mision);
            }
        }

        // GET: MisionController/Edit/5
        public ActionResult Edit(string nombre)
        {
            ViewBag.astronautas = service.mostrarAstronautas();
            ViewBag.naves = service.mostrarNaves().Where(n => n.Aceptabilidad).ToList();
            var misionBuscada = service.buscarMision(nombre);

            return View(misionBuscada);
        }

        // POST: MisionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mision mision)
        {
            try
            {
                if (ModelState.IsValid)
                    service.actualizarMision(mision);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MisionController/Delete/5
        public ActionResult Delete(string nombre)
        {
            try
            {
                var misionEliminada = service.buscarMision(nombre);
                service.eliminarMision(misionEliminada);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        // POST: MisionController/Delete/5
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
