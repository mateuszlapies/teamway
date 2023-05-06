using Personality.Model;

namespace Personality.Data
{
    public class SessionDto
    {
        public long Id { get; set; }
        public IEnumerable<SelectionsDto>? Selections { get; set; }
        public int? Score { get; set; }
    }
}
