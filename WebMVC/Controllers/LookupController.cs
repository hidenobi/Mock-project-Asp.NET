using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using DataAccessLayer.Entities;

namespace WebMVC.Controllers
{
    [Route("[controller]")]
    public class LookupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
