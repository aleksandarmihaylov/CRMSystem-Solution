using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMSystem.ViewModels
{
    public class ProjectVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ProjectVM> Projects { get; set; }
        //list of tasks later on
    }
}