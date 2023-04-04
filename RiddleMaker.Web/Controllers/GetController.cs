using Microsoft.AspNetCore.Mvc;

using RiddleMaker.Common;
using RiddleMaker.Services.Data;
using RiddleMaker.Web.ViewModels;

namespace RiddleMaker.Web.Controllers
{
	public class GetController : Controller
	{
		readonly IRiddlesService riddlesService;

		public GetController(IRiddlesService riddlesService)
		{
			this.riddlesService = riddlesService;
		}

		[HttpGet]
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
