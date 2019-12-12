using Microsoft.AspNetCore.Mvc;
using MathGen.Models;
using MathGen.Configs;
using Microsoft.Extensions.Options;

namespace MathGen.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdditionConfig _additionConfig;
        private readonly SubtractionConfig _subtractionConfig;
        private readonly SukoduConfig _sukoduConfig;

        public HomeController(IOptions<AdditionConfig> additionOptions,
            IOptions<SubtractionConfig> subtractionOptions,
            IOptions<SukoduConfig> sukoduOptions)
        {
            _additionConfig = additionOptions.Value;
            _subtractionConfig = subtractionOptions.Value;
            _sukoduConfig = sukoduOptions.Value;
        }


        public IActionResult Index()
        {
            var container = new MathContainer()
                .SetAddition(_additionConfig)
                .SetSubtraction(_subtractionConfig)
                .SetSudoku(_sukoduConfig);
            return View(container);
        }
    }
}
