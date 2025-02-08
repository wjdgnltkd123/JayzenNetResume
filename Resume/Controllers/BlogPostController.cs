using Microsoft.AspNetCore.Mvc;

namespace Resume.Controllers
{
    public class BlogPostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
