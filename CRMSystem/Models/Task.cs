using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMSystem.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public bool IsFinished { get; set; }
        public int ContactId { get; set; }
        public int ProjectId { get; set; }
    }
}