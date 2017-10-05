﻿using System;
using System.Collections.Generic;
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
        public int CompanyId { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public List<ContactVM> Contacts { get; set; }
        public List<CompanyVM> Companies { get; set; }
    }
}