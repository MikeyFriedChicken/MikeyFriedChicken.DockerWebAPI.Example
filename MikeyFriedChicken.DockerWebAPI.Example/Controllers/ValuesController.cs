using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MikeyFriedChicken.DockerWebAPI.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]

        public ActionResult<IEnumerable<string>> Get()
        {
            string computerName = Environment.GetEnvironmentVariable("COMPUTERNAME") ?? "None";
            string hostName = Environment.GetEnvironmentVariable("HOSTNAME") ?? "None";
            string processId = Process.GetCurrentProcess().Id.ToString();
            string processName = Process.GetCurrentProcess().ProcessName;
            string machineName = Process.GetCurrentProcess().MachineName;

            ColorConsole.WriteLine("'Get' Request received by '{0}' ", "cyan", hostName);

            return new string[]
            {
                "Computer Name: " + computerName, "Host Name: " + hostName, "Machine Name: " + machineName,
                "Process Id: " + processId, "Process Name: " + processName
            };

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
