using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversidadContoso.Models
{
    public class Alumno
    {
        [Key]
        public int ID_Alumno { get; set; }
        public string Nombre_Alumno { get; set; }
        public string Email_Alumno { get; set; }
        public List<Curso> Cursos { get; set; }
    }
}