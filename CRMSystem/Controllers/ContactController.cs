﻿using CRMSystem.DAL;
using CRMSystem.Models;
using CRMSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSystem.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactVM model)
        {
            //Creating a contact object from the VM
            Contact contact = new Contact();
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Address = model.Address;
            contact.City = model.City;
            contact.Zip = model.Zip;
            contact.Phone = model.Phone;

            ContactRepository contactRepository = new DAL.ContactRepository();
            contactRepository.SaveContact(contact);

            return RedirectToAction("Index");
        }

        public ActionResult Show(int id)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Edit(ContactVM model)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}