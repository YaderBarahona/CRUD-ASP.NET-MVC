//clase modelo que corresponde a una tabla en la db
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Models
{
    public class Libro
    {
        //definimos los campos de la tabla

        //DataAnnotation
        //indicamos que el campo es llave primaria y autoincremental
        [Key]

        //propiedad de tipo de dato int
        public int Id { get; set; }

        //DataAnnotation
        //validar campo (sea obligatorio)
        [Required(ErrorMessage = "Por favor rellene el campo título.")]
        //DataAnnotation
        //validar la longitud de caracteres (maximo caracteres, mensaje, {} posicion de mapeo, minimo de caracteres)
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        //DataAnnotation
        //para cambiar el campo en la aplicacion con tilde
        [Display(Name = "Título")]
        public String Titulo { get; set; }

        [Required(ErrorMessage = "Por favor rellene el campo descripción.")]
        [StringLength(100, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 50)]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }

        [Required(ErrorMessage = "Por favor rellene el campo fecha.")]
        //DataAnnotation
        //configurar solo fecha sin hora
        //queda guardado la fecha con la hora en sql pero en la app solo la fecha
        [DataType(DataType.Date)]
        [Display(Name = "Fecha lanzamiento")]
        public DateTime fechaLanzamiento { get; set; }

        [Required(ErrorMessage = "Por favor rellene el campo autor.")]
        public String autor { get; set; }

        [Required(ErrorMessage = "Por favor rellene el campo precio.")]
        public int precio { get; set; }

    }
}
