using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UsersAdminPanel.Models;

namespace UsersAdminPanel.Controllers
{
    public class UsersController : Controller
    {
        private UsersData db = new UsersData();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "ID,Name")] User user)
        {
            return View("Index", (object)user);
        }

        public ActionResult UsersTableData([Bind(Include = "ID,Name")] User user = null)
        {
            if (ModelState.IsValid && user!=null)
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            return PartialView(db.Users.ToList());
        }
        
        public ActionResult Create()
        {
            return PartialView();
        }
        
        public ActionResult Create([Bind(Include = "ID,Name")] User user)
        {            
            return PartialView(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
