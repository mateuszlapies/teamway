using Personality.Model;

namespace Personality.Data
{
    public class SessionDto
    {
        public long Id { get; set; }
        public List<Selection>? Selections { get; set; }
        public int? Score { get; set; }
    }
}
