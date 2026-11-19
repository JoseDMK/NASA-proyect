using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NASA.Models;
using NASA.Services;

namespace NASA.Controllers
{
    public class NaveController : Controller
    {

        Service services = new Service();
        // GET: NaveController
        public ActionResult Index()
        {
            var lista = services.mostrarNaves();
            return View(lista);
        }


        public ActionResult Buscar(string tipo, string capacidad)
        {
            tipo = tipo ?? "";
            capacidad = capacidad ?? "";
            var lista = services.buscarNavePorTipoYCapacidad(tipo, capacidad);
            return View("Index", lista);
        }

        // GET: NaveController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NaveController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NaveController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nave nave)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    nave.calcularAceptabilidad();
                    services.agregarNave(nave);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NaveController/Edit/5
        public ActionResult Edit(int idNave)
        {
            try
            {
                var nave = services.buscarNave(idNave);
                if (nave == null)
                    return RedirectToAction("Index");

                return View(nave);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: NaveController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Nave nave)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    nave.calcularAceptabilidad();
                    services.editarNave(nave);
                    return RedirectToAction("Index");
                }

                return View(nave);
            }
            catch
            {
                return View(nave);
            }
        }

        // GET: NaveController/Delete/5
        public ActionResult Delete(int idNave)
        {
            services.eliminarNave(idNave);
            return RedirectToAction("Index");
        }

        // POST: NaveController/Delete/5
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
