using Microsoft.AspNetCore.Mvc;

namespace TicketHub.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
