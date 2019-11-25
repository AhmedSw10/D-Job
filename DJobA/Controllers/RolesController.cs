using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hhhhh.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DJobA.Controllers
{
    [Authorize(Roles = "Admins")]
    public class RolesController : Controller
    {
        ApplicationDbContext DB = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            return View(DB.Roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(String id)
        {

            var role = DB.Roles.Find(id);
            if(role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    DB.Roles.Add(role);
                    DB.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(role);
            
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(String id)
        {
            var E = DB.Roles.Find(id);
            if (E == null)
            {
                return HttpNotFound();
            }
            return View(E);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(role).State= EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            var E = DB.Roles.Find(id);
            if (E == null)
            {
                return HttpNotFound();
            }
            return View(E);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                var mye = DB.Roles.Find(role.Id);
                DB.Roles.Remove(mye);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
