using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models.ViewModels
{
    public class AnomaliesLoggins
    {
        public string UserName { get; set; }
        public string Device { get; set; }
        public string LoginTime { get; set; }      
        public UnexpectedLogin UnexpectedLogin { get; set; }
    }

    public class UnexpectedLogin
    {
        public string Country { get; set; }
        public string LoginTime { get; set; }
    }
}
