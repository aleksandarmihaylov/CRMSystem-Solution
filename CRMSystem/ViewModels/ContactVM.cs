using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMSystem.ViewModels
{
    public class ContactVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        //[Range(1, int.MaxValue, ErrorMessage = "You need to select a company")]
        //TO DO Create and edit only after value 1! 
        // because dropdown value 0 is please select a company
        public int CompanyId { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public List<ContactVM> Contacts { get; set; }
        // for creating a contact we need a list of companies
        public List<CompanyVM> Companies { get; set; }
        //for presenting the company this contact is working at
        public CompanyVM Company { get; set; }
    }
}