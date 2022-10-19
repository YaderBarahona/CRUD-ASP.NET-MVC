using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Controllers
{
    public class LibrosController : Controller
    {
        //variable para acceder a la db
        private readonly ApplicationDbContext _context;

        //constructor para inicializar el acceso del ApplicationDbContext
        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }


        //metodo index por defecto 
        public IActionResult Index()
        {
            //lista de los libros
            //lista enumerable
            IEnumerable<Libro> lista_libro = _context.Libro;
            return View(lista_libro);
        }

        //Http get create
        public IActionResult Create()
        {
            return View();
        }

        //Http post create recibe parametro libro
        //indicamos el tipo de metodo HttpPost
        [HttpPost]
        public IActionResult Create(Libro libro)
        {
            //validacion del modelo (required, stringlength, etc)
            if (ModelState.IsValid)
            {
                //añadimos el libro
                _context.Libro.Add(libro);
                //guardamos los cambios
                _context.SaveChanges();
                TempData["mensaje"] = "Libro creado";
                //redireccion hacia al index luego de guardar
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http get edit
        public IActionResult Edit(int? id)
        {
            //condicional si no se esta enviando el id
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener el libro por medio de _context
            var libro = _context.Libro.Find(id);

            //condicional si no se encuentra el libro con ese id
            if (libro == null)
            {
                return NotFound();
            }

            //si esta correcto retorna el libro
            return View(libro);
        }

        //Http post edit
        [HttpPost]
        public IActionResult Edit(Libro libro)
        {
            //validacion del modelo (required, stringlength, etc)
            if (ModelState.IsValid)
            {
                //añadimos el libro
                _context.Libro.Update(libro);
                //guardamos los cambios
                _context.SaveChanges();
                TempData["mensaje"] = "Libro actualizado";
                //redireccion hacia al index luego de guardar
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http get delete
        public IActionResult Delete(int? id)
        {
            //condicional si no se esta enviando el id
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener el libro por medio de _context
            var libro = _context.Libro.Find(id);

            //condicional si no se encuentra el libro con ese id
            if (libro == null)
            {
                return NotFound();
            }

            //si esta correcto retorna el libro
            return View(libro);
        }

        //Http post edit
        [HttpPost]
        //proteccion para los formularios para que no se hagan peticiones masivas de terceros (bots)
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {
            //obtencion libro por id 
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

  
                //borramos el libro
                _context.Libro.Remove(libro);
                //guardamos los cambios
                _context.SaveChanges();
                TempData["mensaje"] = "Libro eliminado";
                //redireccion hacia al index luego de guardar
                return RedirectToAction("Index");
        
        }
    }


}
