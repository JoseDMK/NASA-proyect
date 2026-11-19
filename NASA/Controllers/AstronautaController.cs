using Microsoft.AspNetCore.Mvc;
using NASA.Models; 
using NASA.Services;

namespace NASA.Controllers
{
    public class AstronautaController : Controller
    {
      
        Service services = new Service();

        // GET: AstronautaController
        public ActionResult Index()
        {
           var lista = services.mostrarAstronautas();
           return View(lista);
        }

        // GET: AstronautaController/Buscar
        public ActionResult Buscar(string profesion, string nombre)
        {
            profesion = profesion ?? "";
            nombre = nombre ?? "";
            var lista = services.buscarAstronautaPorProfesionYNombre(profesion, nombre);
            return View("Index", lista);
        }

        // GET: AstronautaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AstronautaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Astronauta astronauta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    astronauta.calcularSalario();
                    services.agregarAstronauta(astronauta);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AstronautaController/Edit/5
        public ActionResult Edit(int cedula)
        {
            try
            {
                var astronauta = services.buscarAstronauta(cedula);
                if (astronauta == null)
                    return RedirectToAction("Index");
                return View(astronauta);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: AstronautaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Astronauta astronauta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    astronauta.calcularSalario();
                    services.editarAstronauta(astronauta);
                    return RedirectToAction("Index");
                }
                return View(astronauta);
            }
            catch
            {
                return View(astronauta);
            }
        }

        // GET: AstronautaController/Delete/5
        public ActionResult Delete(int cedula)
        {
            var astronauta = services.buscarAstronauta(cedula);
            services.eliminarAstronauta(cedula);
            return RedirectToAction("Index");
        }

        // POST: AstronautaController/Delete/5
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
