using DerdinizKimComWeb.BusinessLayer;
using DerdinizKimComWeb.Entities;
using DerdinizKimComWeb.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DerdinizKimComWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           
            DertManager dm = new DertManager();

            return View(dm.GetDerts().OrderByDescending(x=>x.duzenlendigitarih).ToList());
        }

        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryManager cm = new CategoryManager();
            Kategori cat = cm.GetCategoriById(id.Value);
            if (cat == null)
            {
                return HttpNotFound();
            }
            return View("Index", cat.Dertler.OrderByDescending(x=>x.duzenlendigitarih).ToList());
        }

        public ActionResult MostLiked()
        {
            DertManager dm = new DertManager();

            return View("Index", dm.GetDerts().OrderByDescending(x => x.begenisayisi).ToList());
        }

        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model )
        {
            if (ModelState.IsValid)
            {
                DerdinizKimComUserManager dkcum = new DerdinizKimComUserManager();
                BusinessLayerResults<User> res = dkcum.LoginUser(model);
                        if (res.Errors.Count > 0)
                            {
                                 res.Errors.ForEach(x => ModelState.AddModelError("", x));
                    
                                return View(model);
                            }

                Session["login"] = res.Result;
                return RedirectToAction("Index");

            }
          
            return View(model);
        }

        public ActionResult Register()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {

          
            
           

            if (ModelState.IsValid)
            {
                DerdinizKimComUserManager dkcum = new DerdinizKimComUserManager();
                BusinessLayerResults<User> res= dkcum.RegisterUser(model);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }
                
                
                //try
                //{
                //    dkcum.RegisterUser(model);
                //}
                //catch(Exception ex)
                //{
                //    ModelState.AddModelError("", ex.Message);
                //}



                //    if(model.Username=="dd"){ ModelState.AddModelError("", "Kullanıcı Adı Kullanılıyor"); }
                //    if (model.Email == "dd@dd.com") { ModelState.AddModelError("", "E posta Kullanılıyor"); }
                //    foreach(var item in ModelState)
                //    {
                //        if (item.Value.Errors.Count > 0)
                //        {
                //            return View(model);
                //        }



                return RedirectToAction("RegisterOk");

            }
            return View(model);

        }

        public ActionResult RegisterOk()
        {
            return View();
        }


        public ActionResult Logout()
        {
            return View();
        }

    }
}