using AutoMapper;
using Microsoft.EntityFrameworkCore;

using RiddleMaker.Data;
using RiddleMaker.Data.Models;
using RiddleMaker.Web.ViewModels;

namespace RiddleMaker.Services.Data
{
    public class RiddlesService : IRiddlesService
    {
        readonly IMapper mapper;
        readonly RiddleMakerContext context;

        public RiddlesService(IMapper mapper, RiddleMakerContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task AddAsync(AddRiddleViewModel model)
        {
            Riddle riddle = mapper.Map<Riddle>(model);
            await context.AddAsync(riddle);
            await context.SaveChangesAsync();
        }

        public async Task<GetRiddleViewModel?> GetRandomRiddleAsync()
        {
            if (await context.Riddles.CountAsync() == 0)
            {
                return null;
            }

            Random rnd = new Random();
            int index = rnd.Next(1, await context.Riddles.CountAsync() + 1);

            Riddle? riddle = await context.Riddles.FindAsync(index);
            while (riddle == null)
            {
                index = rnd.Next(1, await context.Riddles.CountAsync());
                riddle = await context.Riddles.FindAsync(index);
            }

            return mapper.Map<GetRiddleViewModel>(riddle);
        }

        public async Task<bool> CheckAnswerAsync(int riddleId, string? answer)
        {
            bool result = (await context.Riddles.FindAsync(riddleId))!.Answer.Text.ToLower() == answer?.ToLower();
            return result;
        }

		public async Task<Riddle> GetRiddleByIdAsync(int riddleId)
        {
            return (await context.Riddles.FindAsync(riddleId))!;
        }

        public async Task<int> RiddlesCountAsync()
        {
            return await context.Riddles.CountAsync();
        }
	}
}
