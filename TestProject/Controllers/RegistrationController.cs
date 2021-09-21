using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Route("api/registration")]
    public class RegistrationController : ControllerBase
    {

        RegistrationDynamicContext context;
        List<string> monthNames = new List<string>{"January", "February", "March", "April", "May", "June",
                                "July", "August", "September", "October", "November", "December" };

        public RegistrationController(RegistrationDynamicContext context)
        {
            this.context = context;
        }

        [Route("bymonth/{date?}")]
        [HttpGet]
        public IActionResult Get(string date)
        {
            try
            {
                if (String.IsNullOrEmpty(date))
                {
                    date = $"{DateTime.Now.Year}";
                    if(DateTime.Now.Month > 9)
                    {
                        date += $"{DateTime.Now.Month}";
                    }
                    else
                    {
                        date += $"0{DateTime.Now.Month}";
                    }
                }

                int year;
                Int32.TryParse(date.Substring(0, 4), out year);
                string month = date.Substring(4);
                int monthNumber;
                if(month[0] == '0')
                {
                    Int32.TryParse(month[1].ToString(), out monthNumber);
                }
                else
                {
                    Int32.TryParse(date.Substring(4), out monthNumber);
                }
                

                if (monthNumber > 12 || monthNumber < 1)
                {
                    throw new Exception("month value invalid");
                }
                var mName = monthNames[monthNumber - 1];
                var dynamic = context.RegistartionByDevice.ToList();
                UserDevicesViewModel result = null;
                foreach (var item in dynamic)
                {
                    result = new UserDevicesViewModel
                    {
                        Year = item.Year,
                        Month = monthNumber,
                        RegisteredUsers = dynamic.Where(x => x.Month == monthNames[monthNumber - 1] && x.Year == year).Sum(x => x.NumberOfUsers),
                        RegisteredDevices = dynamic.Where(x => x.Month == monthNames[monthNumber - 1] && x.Year == year).Select(x => new UserDevice
                        {
                            Type = x.Device,
                            Value = x.NumberOfUsers

                        }).ToList()
                    };
                }
                if (result.RegisteredDevices.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(result, Formatting.Indented));
                }
                else
                {
                    return StatusCode(404, "No data available");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}
