using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personality.Data;
using Personality.Model;

namespace Personality.Controllers
{
    [ApiController]
    [Route("/backend/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly PersonalityContext context;

        public QuestionsController(PersonalityContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public IQueryable<QuestionDto> GetQuestions()
        {
            return context.Questions.Include(i => i.Answers).OrderBy(o => o.Id).Select(q => new QuestionDto()
            {
                Id = q.Id,
                Text = q.Text,
                Answers = q.Answers.Select(a => new AnswerDto()
                {
                    Id = a.Id,
                    Text = a.Text
                })
            });
        }
    }
}
