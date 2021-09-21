using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Models.ViewModels;

namespace TestProject.Controllers
{
 
    [ApiController]
    [Route("api/sessions")]
    public class SessionsController : ControllerBase
    {

        RegistrationDynamicContext context;

        public SessionsController(RegistrationDynamicContext context)
        {
            this.context = context;
        }

        [Route("byhour")]
        [HttpGet]
        public IActionResult Get()
        {
            string startTime = HttpContext.Request.Query["startTime"];
            string endTime = HttpContext.Request.Query["endTime"];
            DateTime startDate;
            DateTime endDate;
            var resultDuration = context.SessionDuration.ToList();
            var resultSessions = context.SessionsByHour.ToList();

            if (startTime != null)
            {
                startDate = DateTime.Parse(startTime);
                resultDuration = resultDuration.Where(x => x.Date >= startDate.Date && x.Hour >= startDate.Hour).ToList();
                resultSessions = resultSessions.Where(x => x.Hour >= startDate).ToList();
            }
            if (endTime != null)
            {
                endDate = DateTime.Parse(endTime);
                resultDuration = resultDuration.Where(x => x.Date <= endDate.Date && x.Hour <= endDate.Hour).ToList();
                resultSessions = resultSessions.Where(x => x.Hour <= endDate).ToList();
            }

            List<UserSessions> userSessions = new List<UserSessions>();
            foreach(var item in resultDuration)
            {
                SessionsByHour concurSessions = resultSessions.FirstOrDefault(x => x.Hour.Hour == item.Hour && x.Hour.Date == item.Date);
            
                var res = new UserSessions
                {
                    Date = item.Date.Date.ToString("yyyy'-'MM'-'dd"),
                    Hour = (int)item.Hour,
                    TotalTimeForHour = (int)item.TotalSessionDurationForHour,
                    QumulativeForHour = (int)item.TotalSessionDuration,
                    ConcurrentSessions = concurSessions != null ? (int?)concurSessions.MaxSessions : null
                };
                userSessions.Add(res);
            }


            return Ok(JsonConvert.SerializeObject(userSessions, Formatting.Indented));
        }
    }
}
