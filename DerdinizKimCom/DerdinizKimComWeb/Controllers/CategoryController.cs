using DerdinizKimComWeb.BusinessLayer;
using DerdinizKimComWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DerdinizKimComWeb.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        //public ActionResult Select(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CategoryManager cm = new CategoryManager();
        //    Kategori cat = cm.GetCategoriById(id.Value);
        //    if(cat ==null)
        //    {
        //        return HttpNotFound();
        //    }
        //    TempData["mm"] = cat.Dertler;
        //    return RedirectToAction("Index","Home");
        //}
    }
}