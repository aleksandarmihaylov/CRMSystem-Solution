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

                //This code will return only the name of the company which will be presented into the SHOW view
                //TO DO REFACTOR THIS !!!! 
                CompanyRepository companyRepository = new CompanyRepository();
                Company company = companyRepository.LoadCompany(contactvm.CompanyId);
                CompanyVM companyVM = new CompanyVM();
                companyVM.Name = company.Name;
                contactvm.Company = companyVM;

                contactVMs.Add(contactvm);
            }

            ContactVM model = new ContactVM();
            model.Contacts = contactVMs;

            return View(model);
        }
        // GET: Contact/Create
        public ActionResult Create()
        {
            // This will render the name of the contact inside a dropdown list in the view
            CompanyRepository companyRepository = new CompanyRepository();
            List<Company> companies = companyRepository.LoadAllCompanies();
            List<CompanyVM> companyVMs = new List<CompanyVM>();
            
            foreach (Company company in companies)
            {
                CompanyVM cmp = new CompanyVM();
                cmp.Id = company.Id;
                cmp.Name = company.Name;

                companyVMs.Add(cmp);
            }

            ContactVM model = new ContactVM();
            model.Companies = companyVMs;
            return View(model);
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
            //// This will show the company name this person belongs to
            //CompanyRepository companyRepository = new CompanyRepository();
            //Company company = companyRepository.LoadCompanyByCustomerId();
            //List<CompanyVM> companyVMs = new List<CompanyVM>();

            //foreach (Company company in companies)
            //{
            //    CompanyVM cmp = new CompanyVM();
            //    cmp.Id = company.Id;
            //    cmp.Name = company.Name;

            //    companyVMs.Add(cmp);
            //}


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

            //This code will return only the name of the company which will be presented into the SHOW view
            CompanyRepository companyRepository = new CompanyRepository();
            Company company = companyRepository.LoadCompany(model.CompanyId);
            CompanyVM companyVM = new CompanyVM();
            companyVM.Name = company.Name;
            model.Company = companyVM;

            return View(model);
        }
        // GET: Contact/Edit
        public ActionResult Edit(int id)
        {
            // This will render the name of the contact inside a dropdown list in the view
            CompanyRepository companyRepository = new CompanyRepository();
            List<Company> companies = companyRepository.LoadAllCompanies();
            List<CompanyVM> companyVMs = new List<CompanyVM>();

            //ask someone how to do that
            foreach (Company company in companies)
            {
                CompanyVM cmp = new CompanyVM();
                cmp.Id = company.Id;
                cmp.Name = company.Name;

                companyVMs.Add(cmp);
            }

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
            model.Companies = companyVMs;

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