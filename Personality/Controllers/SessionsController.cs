using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personality.Data;
using Personality.Model;
using System.ComponentModel.DataAnnotations;

namespace Personality.Controllers
{
    [ApiController]
    [Route("/backend/[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly PersonalityContext context;

        public SessionsController(PersonalityContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public SessionDto GetSession(long sessionId)
        {
            var sessions = context.Sessions.ToList();

            if (!context.Sessions.Any(q => q.Id == sessionId))
            {
                throw new ValidationException("This set of responses is not available!");
            }

            var session = context.Sessions
                .Include(i => i.Selections)
                .ThenInclude(i => i.Answer)
                .ThenInclude(i => i.Question)
                .Select(s => new SessionDto()
                {
                    Id = s.Id,
                    Selections = s.Selections.Select(sel => new SelectionsDto()
                    {
                        Id = sel.Id,
                        Answer = new AnswerDto()
                        {
                            Id = sel.Answer.Id,
                            Text = sel.Answer.Text,
                            Question = new QuestionDto()
                            {
                                Id = sel.Answer.Question.Id,
                                Text = sel.Answer.Question.Text
                            }
                        }
                    }),
                    Score = s.Selections.Sum(s => s.Answer.Value)
                })
                .Single(q => q.Id == sessionId);

            return session;
        }

        [HttpPut]
        public SessionDto AddSession([FromBody] List<long> answerIds)
        {
            if (answerIds.Distinct().Count() != context.Questions.Count())
            {
                throw new ValidationException("All questions need to have an answer!");
            }

            if (context.Questions
                .Where(q => 
                    q.Answers.Any(a =>
                        answerIds.Contains(a.Id)
                    ))
                .Distinct()
                .Count() != context.Questions.Count())
            {
                throw new ValidationException("Each question can have only one answer!");
            }

            var session = new Session()
            {
                Selections = answerIds.Select(answerId => new Selection()
                {
                    AnswerId = answerId
                }).ToList()
            };
            context.Sessions.Add(session);
            context.SaveChanges();

            return new SessionDto() { Id = session.Id };
        }
    }
}
