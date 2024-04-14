using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Test_MusiscApp.Data;
using Test_MusiscApp.Models;

namespace Test_MusiscApp.Controllers
{
    /// <summary>
    /// Controlador para administrar las canciones.
    /// </summary>
    public class SongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SongController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Muestra el formulario para crear una nueva canción.
        /// </summary>
        /// <param name="albumId">ID del álbum al que pertenece la canción.</param>
        public IActionResult Create(int albumId)
        {
            ViewBag.AlbumId = albumId;
            return View();
        }

        /// <summary>
        /// Crea una nueva canción.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Song song)
        {
            try
            {
                var album = _context.Album.Include(a => a.Songs).FirstOrDefault(a => a.Id == song.Album_Id);

                if (ModelState.IsValid)
                {
                    song.Album = album;
                    _context.Song.Add(song);
                    _context.SaveChanges();
                    return RedirectToAction("Details", "Album", new { albumId = song.Album_Id });
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al crear la canción: " + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error inesperado al crear la canción: " + ex.Message);
            }

            return View(song);
        }

        /// <summary>
        /// Elimina una canción.
        /// </summary>
        public IActionResult Delete(int songId)
        {
            var song = _context.Song.Find(songId);
            if (song == null)
            {
                return NotFound();
            }

            try
            {
                _context.Song.Remove(song);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al eliminar la canción: " + ex.Message);
            }

            return RedirectToAction("Details", "Album", new { albumId = song.Album_Id });
        }

        /// <summary>
        /// Redirige a los detalles del álbum.
        /// </summary>
        public IActionResult Details(int albumId)
        {
            return RedirectToAction("Details", "Album", new { albumId = albumId });
        }

        /// <summary>
        /// Muestra el formulario para editar una canción.
        /// </summary>
        public IActionResult Edit(int id)
        {
            var song = _context.Song.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        /// <summary>
        /// Edita una canción existente.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(song);
                    _context.SaveChanges();
                    return RedirectToAction("Details", "Album", new { albumId = song.Album_Id });
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError("", "Ocurrió un error de concurrencia al editar la canción: " + ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error inesperado al editar la canción: " + ex.Message);
            }

            return View(song);
        }
    }
}
