﻿using Core.Entities;
using Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string Identifier { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Code { get; set; }
    }
}