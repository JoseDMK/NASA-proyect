using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NASA.Models;
using NASA.Services;

namespace NASA.Controllers
{
    public class ExperimentoController : Controller
    {
        Service services = new Service();

        // GET: ExperimentoController
        public ActionResult Index()
        {
            var lista = services.mostrarExperimentos();
            return View(lista);
        }

        // GET: ExperimentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExperimentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExperimentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Experimento experimento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    services.agregarExperimento(experimento);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ExperimentoController/Edit/5
        public ActionResult Edit(string nombre)
        {
            try
            {
                var experimento = services.buscarExperimento(nombre);
                if (experimento == null)
                    return RedirectToAction("Index");

                return View(experimento);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: ExperimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Experimento experimento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    services.editarExperimento(experimento);
                    return RedirectToAction("Index");
                }

                return View(experimento);
            }
            catch
            {
                return View(experimento);
            }
        }

        // GET: ExperimentoController/Delete/5
        public ActionResult Delete(string nombre)
        {
            services.eliminarExperimento(nombre);
            return RedirectToAction("Index");
        }

        // GET: AgregarResultado
        public ActionResult AgregarResultado(string nombre)
        {
            try
            {
                var experimento = services.buscarExperimento(nombre);
                if (experimento == null)
                    return RedirectToAction("Index");

                return View(experimento);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: AgregarResultado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarResultado(Experimento experimento)
        {
            try
            {
                var exp = services.buscarExperimento(experimento.Nombre);

                if (exp != null)
                {
                    // SOLO estos campos
                    exp.ResultadoEsperado = experimento.ResultadoEsperado;
                    exp.Observaciones = experimento.Observaciones;

                    services.editarExperimento(exp);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(experimento);
            }
        }

            // POST: ExperimentoController/Delete/5
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
