using Microsoft.AspNetCore.Mvc;

namespace RiddleMaker.Web.Controllers
{
    public class GetController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }
    }
}
