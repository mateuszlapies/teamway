using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personality.Model;

namespace Personality.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly DatabaseContext context;

        public SessionsController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public Session GetSession(long id)
        {
            return context.Sessions
                .Include(i => i.Selections)
                .Single(q => q.Id == id);
        }
    }
}
