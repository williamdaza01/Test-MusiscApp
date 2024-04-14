using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Test_MusiscApp.Data;
using Test_MusiscApp.Models;

namespace Test_MusiscApp.Controllers
{
    /// <summary>
    /// Controlador para administrar el inventario de álbumes.
    /// </summary>
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Muestra la lista de álbumes en el inventario.
        /// </summary>
        public IActionResult Inventory()
        {
            var albums = _context.Album.ToList();
            return View(albums);
        }

        /// <summary>
        /// Redirige a la acción de creación de un álbum.
        /// </summary>
        public IActionResult Create()
        {
            return RedirectToAction("Create", "Album");
        }

        /// <summary>
        /// Redirige a la acción de creación de una canción en el álbum especificado.
        /// </summary>
        public IActionResult CreateSong(int albumId)
        {
            return RedirectToAction("Create", "Song", new { albumId });
        }

    }
}
