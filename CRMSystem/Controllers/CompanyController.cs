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
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            CompanyRepository companyRepository = new CompanyRepository();

            List<Company> companies = companyRepository.LoadAllCompanies();
            List<CompanyVM> companyVMs = new List<CompanyVM>();

            foreach (Company company in companies)
            {
                CompanyVM companyvm = new CompanyVM();
                companyvm.Id = company.Id;
                companyvm.Name = company.Name;
                companyvm.Address = company.Address;
                companyvm.City = company.City;
                companyvm.Zip = company.Zip;
                companyvm.Phone = company.Phone;

                companyVMs.Add(companyvm);
            }

            CompanyVM model = new CompanyVM();
            model.Companies = companyVMs;
            return View(model);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(CompanyVM model)
        {
            //Creating a Company object from the CompanyVM
            Company company = new Company();
            company.Name = model.Name;
            company.Address = model.Address;
            company.City = model.City;
            company.Zip = model.Zip;
            company.Phone = model.Phone;
            //Create a CompanyRepo for saving
            CompanyRepository companyRepository = new CompanyRepository();
            companyRepository.SaveCompany(company);
            return RedirectToAction("Index");
        }

        // GET: Company/Show
        public ActionResult Show(int id)
        {
            // This will render the information of each user in this company
            ContactRepository contactRepository = new ContactRepository();
            List<Contact> contacts = contactRepository.LoadSpecificContacts(id);
            List<ContactVM> contactVMs = new List<ContactVM>();

            //ask someone how to do that
            foreach (Contact contact in contacts)
            {
                //We want only the first and last name of the user
                ContactVM cont = new ContactVM();
                cont.Id = contact.Id;
                cont.FirstName = contact.FirstName;
                cont.LastName = contact.LastName;

                contactVMs.Add(cont);
            }

            //Showing a company with a list of contacts
            CompanyRepository companyRepository = new CompanyRepository();
            Company company = companyRepository.LoadCompany(id);
            CompanyVM model = new CompanyVM();
            model.Id = company.Id;
            model.Name = company.Name;
            model.Address = company.Address;
            model.City = company.City;
            model.Zip = company.Zip;
            model.Phone = company.Phone;
            model.Contacts = contactVMs;
            return View(model);
        }

        // GET: Company/Edit
        public ActionResult Edit(int id)
        {
            CompanyRepository companyRepository = new CompanyRepository();

            Company company = companyRepository.LoadCompany(id);

            CompanyVM model = new CompanyVM();

            model.Id = company.Id;
            model.Name = company.Name;
            model.Address = company.Address;
            model.City = company.City;
            model.Zip = company.Zip;
            model.Phone = company.Phone;

            return View(model);
        }

        // POST: Company/Edit
        [HttpPost]
        public ActionResult Edit(CompanyVM model)
        {
            Company company = new Company();
            company.Id = model.Id;
            company.Name = model.Name;
            company.Address = model.Address;
            company.City = model.City;
            company.Zip = model.Zip;
            company.Phone = model.Phone;

            CompanyRepository companyRepository = new CompanyRepository();

            companyRepository.UpdateCompany(company);

            return RedirectToAction("Index");
        }

        // GET: Company/Delete
        public ActionResult Delete(int id)
        {
            CompanyRepository companyRepository = new CompanyRepository();
            companyRepository.DeleteCompany(id);
            return RedirectToAction("Index");
        }
    }
}