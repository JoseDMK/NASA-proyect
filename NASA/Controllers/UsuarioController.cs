using Microsoft.AspNetCore.Mvc;
using NASA.Models;
using NASA.Services;

namespace NASA.Controllers
{
    public class UsuarioController : Controller
    {
        // Instancia directa del contexto
        private readonly Service _service = new Service();

        public UsuarioController()
        {
        }

        // GET: Usuario
        public IActionResult Index()
        {
            var usuarios = _service.mostrarUsuarios();
            return View(usuarios);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario, string ConfirmPassword)
        {
            if (usuario.Password != ConfirmPassword)
            {
                ModelState.AddModelError("Password", "La contraseña y la confirmación no coinciden.");
                return View(usuario);
            }

            if (ModelState.IsValid)
            {
                _service.agregarUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public IActionResult Edit(int cedula)
        {
            var usuario = _service.buscarUsuario(cedula);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _service.editarUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public IActionResult Delete(int cedula)
        {
            var usuario = _service.buscarUsuario(cedula);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int cedula)
        {
            _service.eliminarUsuario(cedula);
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuario/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Usuario/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Usuario usuario)
        {
            try
            {
                _service.login(usuario);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.MessageError = ex.Message;
                return View();
            }
        }

        // GET: Usuario/ChangePassword/5
        public IActionResult ChangePassword(int cedula)
        {
            var usuario = _service.buscarUsuario(cedula);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/ChangePassword/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(int cedula, string nuevaPassword, string confirmPassword)
        {
            if (nuevaPassword != confirmPassword)
            {
                ModelState.AddModelError("Password", "La contraseña y la confirmación no coinciden.");
                return View();
            }

            _service.actualizarPassword(cedula, nuevaPassword);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Usuario");
        }
    }
}
