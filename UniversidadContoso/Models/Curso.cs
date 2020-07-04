using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversidadContoso.Models
{
    public class Curso
    {
        [Key]public int ID_Curso { get; set; }
        public string Titulo_Curso { get; set; }
        public int Capacidad_Curso { get; set; }
        public int DepartamentoID_Depto { get; set; }
        [ForeignKey("DepartamentoID_Depto")]
        public Departamento Departamento { get; set; }
        public int InstructorID_Instructor { get; set; }
        [ForeignKey("InstructorID_Instructor")]
        public Instructor Instructor { get; set; }
        public List<Alumno> Alumno { get; set; }
    }
}