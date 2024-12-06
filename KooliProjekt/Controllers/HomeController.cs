using KooliProjekt.Models;  // Подключаем пространство имен с PagedResultBase
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KooliProjekt.Controllers
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
            // Создаем объект модели PagedResultBase с данными для пагинации
            var model = new PagedResultBase
            {
                CurrentPage = 1,    // Текущая страница
                PageCount = 5,      // Общее количество страниц
                RowCount = 50       // Общее количество строк
            };

            // Передаем модель в представление
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
