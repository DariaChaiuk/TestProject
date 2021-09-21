using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestProject.Models
{
    public partial class RegistrationByMonth
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }
        public int NumberOfUsers { get; set; }
    }
}
