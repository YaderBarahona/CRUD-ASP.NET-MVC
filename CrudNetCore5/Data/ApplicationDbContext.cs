//ApplicationDbContext que recibe el mapeo de todos los modelos que se tengan y asi acceder desde el controlador utilizando esta clase ApplicationDbContext
using CrudNetCore5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Data
{
    //hereda de la clase DbContext (clase propia de asp.net core)
    public class ApplicationDbContext: DbContext
    {
        //constructor de la clase con parametros
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //instanciamiento de los modelos
        //acceso a la tabla
        public DbSet<Libro> Libro { get; set; }
    }
}
