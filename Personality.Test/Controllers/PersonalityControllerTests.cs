using Personality.Controllers;
using Personality.Model;

namespace Personality.Test.Controllers
{
    public class PersonalityControllerTests
    {
        private PersonalityContext context;

        [SetUp]
        public void Setup()
        {
            context = new PersonalityContext();
            context.Database.EnsureCreated();
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void PersonalityOutcomeBasedOnScoreTest(long personalityId)
        {
            var personality = context.Personalities.Single(q => q.Id == personalityId);
            var controller = new PersonalitiesController(context);

            var resultMin = controller.GetPersonality(personality.Min);
            var resultMax = controller.GetPersonality(personality.Max);

            Assert.That(resultMin.Title, Is.EqualTo(personality.Title));
            Assert.That(resultMax.Title, Is.EqualTo(personality.Title));
            Assert.That(resultMin.Description, Is.EqualTo(personality.Description));
            Assert.That(resultMax.Description, Is.EqualTo(personality.Description));
        }
    }
}
