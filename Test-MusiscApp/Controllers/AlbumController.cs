using Microsoft.AspNetCore.Mvc;
using Test_MusiscApp.Data;
using Test_MusiscApp.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace Test_MusiscApp.Controllers
{
    public class AlbumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlbumController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Muestra el formulario para crear un nuevo álbum.
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Crea un nuevo álbum.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Album.Add(album);
                    _context.SaveChanges();
                    return RedirectToAction("CreationSuccess", "Album");
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al crear el álbum: " + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error inesperado al crear el álbum: " + ex.Message);
            }

            return View(album);
        }

        /// <summary>
        /// Muestra la vista de creación exitosa del álbum.
        /// </summary>
        public IActionResult CreationSuccess()
        {
            return View();
        }

        /// <summary>
        /// Muestra los detalles de un álbum específico.
        /// </summary>
        public IActionResult Details(int albumId)
        {
            var album = _context.Album.Include(a => a.Songs).FirstOrDefault(a => a.Id == albumId);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        /// <summary>
        /// Elimina un álbum.
        /// </summary>
        public IActionResult Delete(int albumId)
        {
            var album = _context.Album.Find(albumId);
            if (album == null)
            {
                return NotFound();
            }

            try
            {
                _context.Album.Remove(album);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al eliminar el álbum: " + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error inesperado al eliminar el álbum: " + ex.Message);
            }

            return RedirectToAction("Inventory", "Inventory");
        }

        /// <summary>
        /// Muestra el formulario para editar un álbum.
        /// </summary>
        public IActionResult Edit(int id)
        {
            var album = _context.Album.Find(id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        /// <summary>
        /// Edita un álbum existente.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Album album)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(album);
                    _context.SaveChanges();
                    return RedirectToAction("Details", "Album", new { albumId = album.Id });
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError("", "Ocurrió un error de concurrencia al editar el álbum: " + ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error inesperado al editar el álbum: " + ex.Message);
            }

            return View(album);
        }
    }
}
