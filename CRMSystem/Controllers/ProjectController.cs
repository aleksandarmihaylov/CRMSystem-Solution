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
                
                projectVMs.Add(projectVM);
            }

            ProjectVM model = new ProjectVM();
            model.Projects = projectVMs;

            return View(model);
        }
        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectVM model)
        {
            Project project = new Project();
            project.Name = model.Name;
            project.Description = model.Description;

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

            return View(model);
        }
        //GET: Project/Edit
        public ActionResult Edit(int id)
        {
            ProjectRepository projectRepository = new ProjectRepository();
            Project project = projectRepository.LoadProject(id);
            ProjectVM model = new ProjectVM();

            model.Id = project.Id;
            model.Name = project.Name;
            model.Description = project.Description;

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