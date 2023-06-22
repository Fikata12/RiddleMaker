using Microsoft.AspNetCore.Mvc;
using RiddleMaker.Common;
using RiddleMaker.Services.Data;
using RiddleMaker.Web.ViewModels;

namespace RiddleMaker.Web.Controllers
{
    public class RiddleController : Controller
    {
        readonly IRiddlesService riddlesService;

        public RiddleController(IRiddlesService riddlesService)
        {
            this.riddlesService = riddlesService;
        }

        public IActionResult Add()
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

        public async Task<IActionResult> Get()
        {
            return View(await riddlesService.GetRandomRiddleAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CheckAnswer(GetRiddleViewModel model)
        {
            model.Riddle = (await riddlesService.GetRiddleByIdAsync(model.Id)).Text;
            if (await riddlesService.CheckAnswerAsync(model.Id, model.UserAnswer))
            {
                model.IsCorrect = true;
                model.Message = Messages.CorrectAnswerMessage;
            }
            else
            {
                model.IsCorrect = false;
                model.Message = Messages.WrongAnswerMessage;
            }
            return View("Get", model);
        }
    }
}
