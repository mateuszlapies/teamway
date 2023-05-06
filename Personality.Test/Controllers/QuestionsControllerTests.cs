using Personality.Controllers.OData;
using Personality.Model;

namespace Personality.Test.Controllers
{
    public class QuestionsControllerTests
    {
        private DatabaseContext context;

        [SetUp]
        public void Setup()
        {
            context = new DatabaseContext();
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
