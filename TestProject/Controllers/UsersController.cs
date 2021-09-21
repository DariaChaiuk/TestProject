using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Models.ViewModels;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        RegistrationDynamicContext context;

        public UsersController(RegistrationDynamicContext context)
        {
            this.context = context;
        }

        [Route("anomalies")]
        [HttpGet]
        public IActionResult Get()
        {
            var sessionsMoreOneDevice = context.SessionsMoreOneDevice.ToList();
            var logginnAnotherCountry = context.LogginAnotherCountry.ToList();

            List<AnomaliesLoggins> anomalies = new List<AnomaliesLoggins>();

            foreach (var item in sessionsMoreOneDevice)
            {
                var loggin = logginnAnotherCountry.FirstOrDefault(x => x.UserName == item.UserName);
                UnexpectedLogin unexpected;

                if(loggin != null)
                {
                    unexpected = new UnexpectedLogin {
                       Country = loggin.Country,
                       LoginTime = loggin.LoginTs.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss")
                    };

                }
                else
                {
                    unexpected = null;
                }

                var res = new AnomaliesLoggins
                {
                    UserName = item.UserName,
                    Device = item.DeviceName,
                    LoginTime = item.LoginTs.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"),
                    UnexpectedLogin = unexpected
                };

                anomalies.Add(res);
            }

            return Ok(anomalies);
        }
    }
}
