using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class BusinessController : Controller
    {


        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return View("Error");

            }
        }
    }

}