using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace FINALP2.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        DepartamentoNegocio departamentoNegocio = new DepartamentoNegocio();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult Details()
        {
            return View(usuarioNegocio.ShowUsers());
        }

        // GET: Usuario/Create
        public ActionResult Create(){

            List<SelectListItem>
            Departamentos = departamentoNegocio.ShowDepartments().ConvertAll(departamentoNegocio =>

            {
                return new SelectListItem()
                {
                    Text = departamentoNegocio.Nombre.ToString(),
                    Value = departamentoNegocio.ID.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = Departamentos;


            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuarios usuario){


            usuarioNegocio.CreateUsers(usuario);
                    
                // TODO: Add insert logic here

                return RedirectToAction("Index");
           
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View(usuarioNegocio.usersEdit(id));
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuarios usuario)
        {
            usuarioNegocio.Edit(usuario);
            
                // TODO: Add update logic here

                return RedirectToAction("Index");
            
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View(usuarioNegocio.usersEdit(id));
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(Usuarios usuario)
        {
            usuarioNegocio.Delete(usuario);

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            
        }
    }
}
