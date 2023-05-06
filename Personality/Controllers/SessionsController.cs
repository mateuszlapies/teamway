using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personality.Data;
using Personality.Model;
using System.ComponentModel.DataAnnotations;

namespace Personality.Controllers
{
    public class SessionsController : Controller
    {
        private readonly DatabaseContext context;

        public SessionsController(DatabaseContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public SessionDto GetSession(long sessionId)
        {
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
                            Text = sel.Answer.Text
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

            var session = context.Sessions.Add(new Session()).Entity;
            var selections = answerIds.Select(answerId => new Selection()
            {
                AnswerId = answerId,
                SessionId = session.Id
            });
            context.Selections.AddRange(selections);
            context.SaveChanges();
            return new SessionDto() { Id = session.Id };
        }
    }
}
