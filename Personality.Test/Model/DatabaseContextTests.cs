using Personality.Model;

namespace Personality.Test.Model
{
    public class DatabaseContextTests
    {
        private PersonalityContext context;

        [SetUp]
        public void Setup()
        {
            context = new PersonalityContext();
            context.Database.EnsureCreated();
        }

        [Test]
        public void DatabaseContentVerificationTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(context.Questions.ToList(), Has.Count.EqualTo(5));
                Assert.That(context.Answers.ToList(), Has.Count.EqualTo(20));
            });
        }
    }
}