using MathLearner.Domain.Entities;
using MathLearner.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MathLearner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuizController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllQuizzes()
        {
            var result = await _unitOfWork.QuizRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quiz>> GetQuiz(int id)
        {
            var result = await _unitOfWork.QuizRepository.Get(x => x.Id == id);

            if (result == null)
            {
                return NotFound("Quiz not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Quiz>>> AddQuiz(Quiz quiz)
        {
            await _unitOfWork.QuizRepository.Add(quiz);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Quiz>>> UpdateQuiz(Quiz quiz)
        {
            await _unitOfWork.QuizRepository.Update(quiz);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Quiz>>> DeleteQuiz(Quiz quiz)
        {
            await _unitOfWork.QuizRepository.Remove(quiz);
            return Ok();
        }
    }
}
