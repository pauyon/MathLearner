using MathLearner.Domain.Entities;
using MathLearnerWasmApp.StaticClasses;

namespace MathLearnerWasmApp.Services.QuizService
{
    public class QuizService : Service<Quiz>, IQuizService
    {
        public QuizService(HttpClient httpClient) : base(httpClient, SiteConstants.Controller.Quiz)
        {
        }
    }
}
