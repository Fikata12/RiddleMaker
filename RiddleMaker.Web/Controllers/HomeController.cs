using Microsoft.AspNetCore.Mvc;

using RiddleMaker.Services.Data;

namespace RiddleMaker.Web.Controllers
{
    public class HomeController : Controller
    {
		readonly IRiddlesService riddlesService;

		public HomeController(IRiddlesService riddlesService)
		{
			this.riddlesService = riddlesService;
		}

		public async Task<IActionResult> Index()
        {
            return View(await riddlesService.RiddlesCountAsync());
        }
	}
}