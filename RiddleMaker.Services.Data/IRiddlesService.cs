using RiddleMaker.Data.Models;
using RiddleMaker.Web.ViewModels;

namespace RiddleMaker.Services.Data
{
    public interface IRiddlesService
    {
        Task AddAsync(AddRiddleViewModel model);

        Task<GetRiddleViewModel?> GetRandomRiddleAsync();

        Task<bool> CheckAnswer(int riddleId, string answer);

	}
}