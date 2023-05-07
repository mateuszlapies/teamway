using Microsoft.AspNetCore.Mvc;
using Personality.Data;
using Personality.Model;

namespace Personality.Controllers
{
    [ApiController]
    [Route("/backend/[controller]")]
    public class PersonalitiesController
    {
        private readonly PersonalityContext context;

        public PersonalitiesController(PersonalityContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public PersonalityDto GetPersonality(int score)
        {
            return context.Personalities
                .Where(q => q.Min <= score && q.Max >= score)
                .Select(s => new PersonalityDto()
                {
                    Title = s.Title,
                    Description = s.Description,
                })
                .Single();
        }
    }
}
