using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MathGen.Models;

namespace MathGen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var container = new MathContainer().SetAddition(2, 10, 15).SetSudoku(2, 5);
            return View(container);
        }
    }
}
