using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversidadContoso.DAL;
using UniversidadContoso.Models;

namespace UniversidadContoso.Controllers
{
    public class DepartamentoController : Controller
    {
        static List<Departamento> Departamentos = new List<Departamento>();
        private ContosoContext ContosoCont = new ContosoContext();
        public ActionResult ListaDepartamentos()
        {
            Departamentos = ContosoCont.Departamentoo.ToList();
            if (Departamentos == null)
            {
                Departamentos = new List<Departamento>();
            }
            return View(Departamentos);
        }
        public ActionResult EditarDepto(int Id)
        {
            Departamento DepartamentoFiltrado = ContosoCont.Departamentoo.Where(d => d.ID_Depto == Id).FirstOrDefault();
            return View(DepartamentoFiltrado);
        }
        public ActionResult FormDepto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearDepartamento (FormCollection form)
        {
            Departamentos = ContosoCont.Departamentoo.ToList();
            if(Departamentos == null)
            {
                Departamentos = new List<Departamento>();
            }
            var depto = new Departamento();
            depto.Titulo_Depto = form["Titulo_Depto"];
            depto.Descripcion_Depto = form["Descripcion_Depto"];

            ContosoCont.Departamentoo.Add(depto);
            ContosoCont.SaveChanges();

            return RedirectToAction("ListaDepartamentos");
        }
        public ActionResult EditarDepartamento(FormCollection form)
        {
            Departamentos = ContosoCont.Departamentoo.ToList();

            if (Departamentos == null)
            {
                Departamentos = new List<Departamento>();
            }

            string Descripcion = form["Descripcion_Depto"];

            var id = form["Id"];
            var isExistingDepartment = Departamentos.Where(d => d.ID_Depto == int.Parse(form["ID_Depto"])).FirstOrDefault();

            if (isExistingDepartment != null)
            {
                isExistingDepartment.Descripcion_Depto = Descripcion;
            }

            ContosoCont.SaveChanges();

            return RedirectToAction("ListaDepartamentos");

        }
        public ActionResult DeleteDepto(int Id)
        {
           
            var DeptoDelete = ContosoCont.Departamentoo.ToList().Find(d => d.ID_Depto == Id);
            ContosoCont.Departamentoo.Remove(DeptoDelete);
            ContosoCont.SaveChanges();
            return RedirectToAction("ListaDepartamentos");


        }

        public ActionResult SearchDepto(string searchDepto)
        {
            var cont = ContosoCont.Departamentoo;
            var res = cont.Where(x => x.Titulo_Depto.Contains(searchDepto) || searchDepto == null).ToList();
            return View("ListaDepartamentos", res);
        }
    }
}