using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace FINALP2.Controllers
{
    public class DepartamentosController : Controller
    {

        DepartamentoNegocio departamentoNegocio = new DepartamentoNegocio();


        // GET: Departamentos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(){

            return View(departamentoNegocio.ShowDepartments());
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        [HttpPost]
        public ActionResult Create(Departamentos departamentos)
        {
           
            
                departamentoNegocio.CreateDepartment(departamentos);

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            
            
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(int id) {

            return View(departamentoNegocio.departamentosEdit(id));
        }

        // POST: Departamentos/Edit/5
        [HttpPost]
        public ActionResult Edit(Departamentos departamentos)
        {

            departamentoNegocio.EditDepartments(departamentos);
             
                return RedirectToAction("Index");
         
            
        }

        // GET: Departamentos/Delete/5
        public ActionResult Delete(int id)

        {
            return View(departamentoNegocio.departamentosEdit(id));
        }

        // POST: Departamentos/Delete/5
        [HttpPost]
        public ActionResult Delete(Departamentos departamentos){
            departamentoNegocio.Borrar(departamentos);
            
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            
            
            
                
            
        }
    }
}
