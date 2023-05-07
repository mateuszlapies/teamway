using Personality.Controllers;
using Personality.Model;

namespace Personality.Test.Controllers
{
    public class QuestionsControllerTests
    {
        private PersonalityContext context;

        [SetUp]
        public void Setup()
        {
            context = new PersonalityContext();
            context.Database.EnsureCreated();
        }

        [Test]
        public void GettingAllQuestionsTest()
        {
            var controller = new QuestionsController(context);

            var result = controller.Get();

            Assert.That(result.Count(), Is.EqualTo(5));
            Assert.That(result.First().Answers.Count(), Is.EqualTo(4));
        }
    }
}
