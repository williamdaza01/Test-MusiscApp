using Microsoft.AspNetCore.Mvc;
using Test_MusiscApp.Data;
using Test_MusiscApp.Models;
using System;

namespace Test_MusiscApp.Controllers
{
    /// <summary>
    /// Controlador para el registro de clientes.
    /// </summary>
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor del controlador RegisterController.
        /// </summary>
        /// <param name="context">El contexto de la base de datos.</param>
        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para mostrar el formulario de registro.
        /// </summary>
        /// <returns>La vista Register.</returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Método para procesar el registro de un cliente.
        /// </summary>
        /// <param name="cliente">El cliente a registrar.</param>
        /// <returns>Una redirección a la acción RegistroExitoso si el registro fue exitoso, 
        /// o la vista Register con mensajes de error si hubo problemas.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Cliente cliente)
        {
            try
            {
                // Validar modelo antes de procesar
                if (ModelState.IsValid)
                {
                    // Agregar el cliente a la base de datos
                    _context.Client.Add(cliente);
                    _context.SaveChanges();

                    // Una vez guardado el cliente, redirigir a una página de confirmación
                    return RedirectToAction(nameof(RegistroExitoso));
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                ModelState.AddModelError("", "Ocurrió un error al procesar el registro: " + ex.Message);
            }

            // Si hay errores de validación o al guardar en la base de datos,
            // vuelve a mostrar el formulario con los mensajes de error
            return View(cliente);
        }

        /// <summary>
        /// Método para mostrar una página de confirmación de registro exitoso.
        /// </summary>
        /// <returns>La vista RegistroExitoso.</returns>
        public IActionResult RegistroExitoso()
        {
            // Redirigir a la vista de registro exitoso
            return View("RegistroExitoso");
        }
    }
}
