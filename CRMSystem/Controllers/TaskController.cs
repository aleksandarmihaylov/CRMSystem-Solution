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
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            TaskRepository taskRepository = new TaskRepository();
            ContactRepository contactRepository = new ContactRepository();
            ProjectRepository projectRepository = new ProjectRepository();
            List<Task> tasks = taskRepository.LoadAllTasks();
            List<TaskVM> taskVMs = new List<TaskVM>();

            foreach (Task task in tasks)
            {
                TaskVM taskVM = new TaskVM();
                taskVM.Id = task.Id;
                taskVM.Name = task.Name;
                taskVM.Description = task.Description;
                taskVM.Hours = task.Hours;
                taskVM.IsFinished = task.IsFinished;
                taskVM.ContactId = task.ContactId;
                taskVM.ProjectId = task.ProjectId;

                //this will load the contact assigned to this task / his first and last name
                Contact contact = contactRepository.LoadContact(taskVM.ContactId);
                ContactVM contactVM = new ContactVM();
                contactVM.FirstName = contact.FirstName;
                contactVM.LastName = contact.LastName;
                //this will load the project name which is this task from
                Project project = projectRepository.LoadProject(taskVM.ProjectId);
                ProjectVM projectVM = new ProjectVM();
                projectVM.Name = project.Name;

                taskVM.Contact = contactVM;
                taskVM.Project = projectVM;

                taskVMs.Add(taskVM);
            }

            TaskVM model = new TaskVM();
            model.Tasks = taskVMs;
            return View(model);
        }
        // GET: Task/Create
        public ActionResult Create()
        {
            ContactRepository contactRepository = new ContactRepository();
            List<Contact> contacts = contactRepository.LoadAllContacts();
            List<ContactVM> contactVMs = new List<ContactVM>();

            foreach (Contact contact in contacts)
            {
                ContactVM cont = new ContactVM();
                cont.Id = contact.Id;
                cont.FirstName = contact.FirstName;
                cont.LastName = contact.LastName;

                contactVMs.Add(cont);
            }

            ProjectRepository projectRepository = new ProjectRepository();
            List<Project> projects = projectRepository.LoadAllProjects();
            List<ProjectVM> projectVMs = new List<ProjectVM>();

            foreach (Project project in projects)
            {
                ProjectVM proj = new ProjectVM();
                proj.Id = project.Id;
                proj.Name = project.Name;

                projectVMs.Add(proj);
            }

            TaskVM model = new TaskVM();
            model.Contacts = contactVMs;
            model.Projects = projectVMs;
            return View(model);
        }

        // POST: Task/Create
        //wants the view model not id
        [HttpPost]
        public ActionResult Create(TaskVM model)
        {
            Task task = new Task();
            task.Name = model.Name;
            task.Description = model.Description;
            task.Hours = model.Hours;
            // we do not set this because when we create a task it is automatically known that the task is not finished
            //task.IsFinished = model.IsFinished;
            task.ContactId = model.ContactId;
            task.ProjectId = model.ProjectId;

            TaskRepository taskRepository = new TaskRepository();
            taskRepository.SaveTask(task); 
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
            TaskRepository taskRepository = new TaskRepository();
            Task task = taskRepository.LoadTask(id);
            TaskVM model = new TaskVM();

            model.Id = task.Id;
            model.Name = task.Name;
            model.Description = task.Description;
            model.Hours = task.Hours;
            model.IsFinished = task.IsFinished;
            model.ContactId = task.ContactId;
            model.ProjectId = task.ProjectId;

            ContactRepository contactRepository = new ContactRepository();
            List<Contact> contacts = contactRepository.LoadAllContacts();
            List<ContactVM> contactVMs = new List<ContactVM>();

            foreach (Contact contact in contacts)
            {
                ContactVM cont = new ContactVM();
                cont.Id = contact.Id;
                cont.FirstName = contact.FirstName;
                cont.LastName = contact.LastName;

                contactVMs.Add(cont);
            }

            ProjectRepository projectRepository = new ProjectRepository();
            List<Project> projects = projectRepository.LoadAllProjects();
            List<ProjectVM> projectVMs = new List<ProjectVM>();

            foreach (Project project in projects)
            {
                ProjectVM proj = new ProjectVM();
                proj.Id = project.Id;
                proj.Name = project.Name;

                projectVMs.Add(proj);
            }

            model.Contacts = contactVMs;
            model.Projects = projectVMs;

            return View(model);
        }
        // POST: Task/Edit
        //wants the viewmodel not id!
        [HttpPost]
        public ActionResult Edit(TaskVM model)
        {
            Task task = new Task();
            task.Id = model.Id;
            task.Name = model.Name;
            task.Description = model.Description;
            task.Hours = model.Hours;
            task.IsFinished = model.IsFinished;
            task.ContactId = model.ContactId;
            task.ProjectId = model.ProjectId;

            TaskRepository taskRepository = new TaskRepository();
            taskRepository.UpdateTask(task);
            return RedirectToAction("Index");
        }
        // GET: Task/Delete
        public ActionResult Delete(int id)
        {
            TaskRepository taskRepository = new TaskRepository();
            taskRepository.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}