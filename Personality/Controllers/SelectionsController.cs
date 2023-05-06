using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personality.Data;
using Personality.Model;
using System.ComponentModel.DataAnnotations;

namespace Personality.Controllers
{
    public class SelectionsController : Controller
    {
        private readonly DatabaseContext context;

        public SelectionsController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public SessionDto GetSelections(long sessionId)
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
                                Selections = s.Selections
                            })
                            .Single(q => q.Id == sessionId);

            session.Score = session.Selections.Sum(s => s.Answer.Value);

            return session;
        }

        [HttpPut]
        public SessionDto AddSelections(SelectionsDto selectionsDto)
        {
            if (selectionsDto.AnswerIds.Distinct().Count() != context.Questions.Count())
            {
                throw new ValidationException("All questions need to have an answer!");
            }

            if (context.Questions
                .Where(q => 
                    q.Answers.Any(a => 
                        selectionsDto.AnswerIds.Contains(a.Id)
                    ))
                .Distinct()
                .Count() != context.Questions.Count())
            {
                throw new ValidationException("Each question can have only one answer!");
            }

            var session = context.Sessions.Add(new Session()).Entity;
            var selections = selectionsDto.AnswerIds.Select(answerId => new Selection()
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
