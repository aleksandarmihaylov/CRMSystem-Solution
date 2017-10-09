using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMSystem.ViewModels
{
    public class TaskVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public bool IsFinished { get; set; }
        public int ContactId { get; set; }
        public int ProjectId { get; set; }

        public List<TaskVM> Tasks { get; set; }
        public List<ProjectVM> Projects { get; set; }
        public ProjectVM Project { get; set; }
        public List<ContactVM> Contacts { get; set; }
        public ContactVM Contact { get; set; }
    }
}