using CRMSystem.DAL;
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
            ContactRepository contactRepository = new ContactRepository();

            List<Contact> contacts = contactRepository.LoadAllContacts();
            List<ContactVM> contactVMs = new List<ContactVM>();

            foreach (Contact contact in contacts)
            {
                ContactVM contactvm = new ContactVM();
                contactvm.Id = contact.Id;
                contactvm.FirstName = contact.FirstName;
                contactvm.LastName = contact.LastName;
                contactvm.Address = contact.Address;
                contactvm.City = contact.City;
                contactvm.Zip = contact.Zip;
                contactvm.Phone = contact.Phone;
                contactvm.CompanyId = contact.CompanyId;

                contactVMs.Add(contactvm);
            }

            ContactVM model = new ContactVM();
            model.Contacts = contactVMs;

            return View(model);
        }
        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Contact/Create
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
            contact.CompanyId = model.CompanyId;

            ContactRepository contactRepository = new DAL.ContactRepository();
            contactRepository.SaveContact(contact);

            return RedirectToAction("Index");
        }
        // GET: Contact/Show
        public ActionResult Show(int id)
        {
            ContactRepository contactRepository = new ContactRepository();

            Contact contact = contactRepository.LoadContact(id);
            ContactVM model = new ContactVM();
            model.Id = contact.Id;
            model.FirstName = contact.FirstName;
            model.LastName = contact.LastName;
            model.Address = contact.Address;
            model.City = contact.City;
            model.Zip = contact.Zip;
            model.Phone = contact.Phone;
            model.CompanyId = contact.CompanyId;
            return View(model);
        }
        // GET: Contact/Edit
        public ActionResult Edit(int id)
        {
            ContactRepository contactRepository = new ContactRepository();
            Contact contact = contactRepository.LoadContact(id);
            ContactVM model = new ContactVM();

            model.Id = contact.Id;
            model.FirstName = contact.FirstName;
            model.LastName = contact.LastName;
            model.Address = contact.Address;
            model.City = contact.City;
            model.Zip = contact.Zip;
            model.Phone = contact.Phone;
            model.CompanyId = contact.CompanyId;

            return View(model);
        }
        // POST: Contact/Edit
        [HttpPost]
        public ActionResult Edit(ContactVM model)
        {
            Contact contact = new Contact();
            contact.Id = model.Id;
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Address = model.Address;
            contact.City = model.City;
            contact.Zip = model.Zip;
            contact.Phone = model.Phone;
            contact.CompanyId = model.CompanyId;

            ContactRepository contactRepository = new ContactRepository();

            contactRepository.UpdateContact(contact);

            return RedirectToAction("Index");
        }
        // GET: Contact/Delete
        public ActionResult Delete(int id)
        {
            ContactRepository contactRepository = new ContactRepository();
            contactRepository.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}