using RiddleMaker.Data.Models;
using RiddleMaker.Web.ViewModels;

namespace RiddleMaker.Services.Data
{
    public interface IRiddlesService
    {
        Task AddAsync(AddRiddleViewModel model);

        Task<GetRiddleViewModel?> GetRandomRiddleAsync();

        Task<bool> CheckAnswerAsync(int riddleId, string? answer);

        Task<Riddle> GetRiddleByIdAsync(int riddleId);

        Task<int> RiddlesCountAsync();
	}
}