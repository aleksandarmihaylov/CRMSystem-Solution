using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSystem.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }
        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        //wants the view model not id
        public ActionResult Create(int id)
        {
            return RedirectToAction("Index");
        }

        // GET: Task/Show
        public ActionResult Show()
        {
            return View();
        }
        // GET: Task/Edit
        public ActionResult Edit(int id)
        {
            return View();
        }
        // POST: Task/Edit
        //wants the viewmodel not id!
        public ActionResult Edit(string id)
        {
            return RedirectToAction("Index");
        }
        // GET: Task/Delete
        public ActionResult Delete()
        {
            return View();
        }
    }
}