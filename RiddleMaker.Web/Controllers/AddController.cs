using Microsoft.AspNetCore.Mvc;

using RiddleMaker.Services.Data;
using RiddleMaker.Web.ViewModels;

namespace RiddleMaker.Web.Controllers
{
    public class AddController : Controller
    {
        readonly IRiddlesService riddlesService;

        public AddController(IRiddlesService riddlesService)
        {
            this.riddlesService = riddlesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRiddleViewModel model)
        {
            if (ModelState.IsValid)
            {
                await riddlesService.AddAsync(model);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
