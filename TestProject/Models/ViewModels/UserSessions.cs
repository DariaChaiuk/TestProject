using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Models.ViewModels
{
    public class UserSessions
    {
        public string Date {get;set;}
        public int Hour { get; set; }
        public int? ConcurrentSessions { get; set; }
        public int TotalTimeForHour { get; set; }
        public int QumulativeForHour { get; set; }
    }
}
