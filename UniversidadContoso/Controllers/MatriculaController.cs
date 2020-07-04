using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversidadContoso.DAL;
using UniversidadContoso.Models;
using System.Data.Entity;

namespace UniversidadContoso.Controllers
{
    public class MatriculaController : Controller
    {
        static List<Curso> Cursos = new List<Curso>();

        private ContosoContext ContosoCont = new ContosoContext();

        public ActionResult ListaMatriculas()
        {
            Cursos = ContosoCont.Cursoo.ToList();

            if (Cursos == null)
            {
                Cursos = new List<Curso>();
            }
            else
            {
                Cursos = ContosoCont.Cursoo.Include(c => c.Departamento).Include(c => c.Instructor).Include(c => c.Alumno).ToList();
            }



            return View(Cursos);
        }


        public ActionResult AgregarMatricula (FormCollection form)
        {
            var Alumno = new Alumno();
            Alumno.Nombre_Alumno = form["Nombre_Alumno"];
            Alumno.Email_Alumno = form["Email_Alumno"];
            

            int IdCurso = int.Parse(form["ID_Curso"]);

            var CursoInscripto = ContosoCont.Cursoo.Include(c => c.Alumno).Where(c => c.ID_Curso == IdCurso).FirstOrDefault();

            CursoInscripto.Alumno.Add(Alumno);
            ContosoCont.SaveChanges();

            Session["Matriculado"] = true;

            return RedirectToAction("ListaCursos");
        }
    }
}
