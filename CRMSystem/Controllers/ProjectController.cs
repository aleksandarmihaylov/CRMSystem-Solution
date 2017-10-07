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
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            ProjectRepository projectRepository = new ProjectRepository();

            List<Project> projects = projectRepository.LoadAllProjects();
            List<ProjectVM> projectVMs = new List<ProjectVM>();

            foreach (var pr in projects)
            {
                ProjectVM projectVM = new ProjectVM();
                projectVM.Id = pr.Id;
                projectVM.Name = pr.Name;
                projectVM.Description = pr.Description;
                projectVM.CompanyId = pr.CompanyId;

                //This code will return only the name of the company which will be presented into the SHOW/Index view
                CompanyRepository companyRepository = new CompanyRepository();
                Company company = companyRepository.LoadCompany(projectVM.CompanyId);
                CompanyVM companyVM = new CompanyVM();
                companyVM.Name = company.Name;
                projectVM.Company = companyVM;

                projectVMs.Add(projectVM);
            }

            ProjectVM model = new ProjectVM();
            model.Projects = projectVMs;

            return View(model);
        }
        // GET: Project/Create
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

            ProjectVM model = new ProjectVM();
            model.Companies = companyVMs;
            return View(model);
        }
        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectVM model)
        {
            Project project = new Project();
            project.Name = model.Name;
            project.Description = model.Description;
            project.CompanyId = model.CompanyId;

            ProjectRepository projectRepository = new ProjectRepository();
            projectRepository.SaveProject(project);
            return RedirectToAction("Index");
        }

        public ActionResult Show(int id)
        {
            ProjectRepository projectRepository = new ProjectRepository();
            Project project = projectRepository.LoadProject(id);
            ProjectVM model = new ProjectVM();

            model.Id = project.Id;
            model.Name = project.Name;
            model.Description = project.Description;
            model.CompanyId = project.CompanyId;

            //This code will return only the name of the company which will be presented into the SHOW/Index view
            CompanyRepository companyRepository = new CompanyRepository();
            Company company = companyRepository.LoadCompany(model.CompanyId);
            CompanyVM companyVM = new CompanyVM();
            companyVM.Name = company.Name;
            model.Company = companyVM;


            return View(model);
        }
        //GET: Project/Edit
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


            ProjectRepository projectRepository = new ProjectRepository();
            Project project = projectRepository.LoadProject(id);
            ProjectVM model = new ProjectVM();

            model.Id = project.Id;
            model.Name = project.Name;
            model.Description = project.Description;
            model.Companies = companyVMs;

            return View(model);
        }
        //POST: Project/Edit
        [HttpPost]
        public ActionResult Edit(ProjectVM model)
        {
            Project project = new Project();

            project.Id = model.Id;
            project.Name = model.Name;
            project.Description = model.Description;
            project.CompanyId = model.CompanyId;

            ProjectRepository projectRepository = new ProjectRepository();

            projectRepository.UpdateProject(project);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ProjectRepository projectRepository = new ProjectRepository();
            projectRepository.DeleteProject(id);

            return RedirectToAction("Index");
        }
    }
}