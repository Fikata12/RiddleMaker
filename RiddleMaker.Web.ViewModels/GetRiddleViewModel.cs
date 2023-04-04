namespace RiddleMaker.Web.ViewModels
{
    public class GetRiddleViewModel
    {
		public int Id { get; set; }
        public string Riddle { get; set; } = null!;
        public string UserAnswer { get; set; } = null!;
        public string Message { get; set; } = null!;
        public bool IsCorrect { get; set; }
    }
}
