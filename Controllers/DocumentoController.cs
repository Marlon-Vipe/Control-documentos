using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace FINALP2.Controllers
{

    [Authorize]
    public class DocumentoController : Controller
    {

        DocumentoNegocio documentoNegocio = new DocumentoNegocio();

        DepartamentoNegocio departamentoNegocio = new DepartamentoNegocio();

        UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();

        // GET: Documento
        public ActionResult Index()
        {
            return View();
        }

        // GET: Documento/Details/5
        public ActionResult Details()
        {

            return View(documentoNegocio.ShowDocuments());
        }

        // GET: Documento/Create
        public ActionResult Create()
        {

            List<SelectListItem>
            Documentos = departamentoNegocio.ShowDepartments().ConvertAll(departamentoNegocio =>

        {
            return new SelectListItem()
            {
                Text = departamentoNegocio.Nombre.ToString(),
                Value = departamentoNegocio.ID.ToString(),
                Selected = false
            };
        });
            ViewBag.items = Documentos;


            List<SelectListItem>
            Usuarios = UsuarioNegocio.ShowUsers().ConvertAll(UsuarioNegocio =>

            {
                return new SelectListItem()
                {
                    Text = UsuarioNegocio.Nombre.ToString(),
                    Value = UsuarioNegocio.ID.ToString(),
                    Selected = false
                };
            });
            ViewBag.items1 = Usuarios;


            return View();
        }

        // POST: Documento/Create
        [HttpPost]
        public ActionResult Create(Documentos documentos)
        {

            documentoNegocio.CreateDocuments(documentos);

            return RedirectToAction("Index");
        }

        // GET: Documento/Edit/5
        public ActionResult Edit(int id)
        {
            return View(documentoNegocio.SelectDocuments(id));
        }

        // POST: Documento/Edit/5
        [HttpPost]
        public ActionResult Edit(Documentos documentos)
        {
            documentoNegocio.EditDocuments(documentos);

            return RedirectToAction("Index");

        }

        // GET: Documento/Delete/5
        public ActionResult Delete(int id)
        {
            return View(documentoNegocio.SelectDocuments(id));
        }

        // POST: Documento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection del)
        {
            documentoNegocio.DeleteDocuments(id);

            return RedirectToAction("Index");

        }

        public ActionResult DocumentsByRange(string Origin, string Destiny)
        {

            return View(documentoNegocio.DocumentsByRange(Origin, Destiny));

        }
    }
}
