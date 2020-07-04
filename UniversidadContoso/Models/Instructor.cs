using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UniversidadContoso.Models
{
    public class Instructor
    {
        [Key]public int ID_Instructor { get; set; }
        public string Nombre_Instructor { get; set; }
        
        public string DiaContrato_Instructor { get; set; }
    }
}