using Microsoft.AspNetCore.Mvc;

namespace RiddleMaker.Web.Controllers
{
    public class AddController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
