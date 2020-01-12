using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CooksProjectCore.Core.CrossCuttingConcerns.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CooksProjectCore.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpGet]
        [Route("logs/exception")]
        public IActionResult GetExceptionLogFiles()
        {
            return Ok(GetLogs("Logs//ExceptionLogs//"));
        }
        [HttpGet]
        [Route("logs/exception/{path}")]
        public IActionResult ReadExceptionLogs(string path)
        {
            return Ok(OpenLog("Logs//ExceptionLogs//" + path));
        }
        [HttpGet]
        [Route("log/performance")]
        public IActionResult GetPerformanceLogFiles()
        {
            return Ok(GetLogs("Logs//PerformanceLogs//"));
        }
        [HttpGet]
        [Route("log/performance/{path}")]
        public IActionResult ReadPerformanceLogs(string path)
        {
            return Ok(OpenLog("Logs//PerformanceLogs//" + path));
        }
        [HttpGet]
        [Route("log/requests")]
        public IActionResult GetRequestsLogs()
        {
            return Ok(GetLogs("Logs//ReuestsLogs//"));
        }
        [HttpGet]
        [Route("log/requests/{path}")]
        public IActionResult ReadRequestsLogs(string path)
        {
            return Ok(OpenLog("Logs//RequestsLogs//" + path));
        }
        private List<string> GetLogs(string path)
        {
            string[] files = Directory.GetFiles(path, "*.json");

            return files.ToList();
        }
        private string OpenLog(string path)
        {
            List<string> files = new List<string>();

            FileStream fileStream = new FileStream(path, FileMode.Open);
            using (StreamReader rdr = new StreamReader(fileStream))
            {
                files.Add(rdr.ReadToEnd());
            }

            string a = "[";
            for (int i = 0; i < files.Count; i++)
            {
                a += files[i];
            }
            a += "]";
            return a;
        }
    }
}