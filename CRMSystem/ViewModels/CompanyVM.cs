using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMSystem.ViewModels
{
    public class CompanyVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

        public List<CompanyVM> Companies { get; set; }
        public List<ContactVM> Contacts { get; set; }
    }
}