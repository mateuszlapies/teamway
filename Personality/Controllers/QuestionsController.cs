using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personality.Model;

namespace Personality.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly DatabaseContext context;

        public QuestionsController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IQueryable<Question> Get()
        {
            return context.Questions.Include(i => i.Answers);
        }
    }
}
