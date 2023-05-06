using Personality.Controllers;
using Personality.Data;
using Personality.Model;
using System.ComponentModel.DataAnnotations;

namespace Personality.Test.Controllers
{
    public class SelectionsControllerTests
    {
        private DatabaseContext context;

        [SetUp]
        public void SetUp()
        {
            context = new DatabaseContext();
            context.Database.EnsureCreated();
        }

        [Test]
        public void GettingSetOfResponsesTest()
        {
            var controller = new SessionsController(context);
            var answerIds = new List<long>() { 1, 5, 9, 13, 17 };
            var session = controller.AddSession(new SelectionsDto() { AnswerIds = answerIds });
            
            var result = controller.GetSession(session.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Selections, Is.Not.Null);
            Assert.That(result.Selections.Count, Is.EqualTo(answerIds.Count));
            Assert.That(result.Score, Is.EqualTo(5));
        }

        [Test]
        public void CreateNewSessionWithSelectionsTest()
        {
            var controller = new SessionsController(context);

            var answerIds = new List<long>() { 1, 5, 9, 13, 17 };

            var result = controller.AddSession(new SelectionsDto() { AnswerIds = answerIds });

            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void TooLittleAnswersProvidedValidationTest()
        {
            var controller = new SessionsController(context);

            var answerIds = new List<long>() { 1 };

            var result = Assert.Throws<ValidationException>(() => controller.AddSession(new SelectionsDto() { AnswerIds = answerIds }));
            Assert.That(result.Message, Is.EqualTo("All questions need to have an answer!"));
        }

        [Test]
        public void MultipleAnswersForSameQuestionValidationTest()
        {
            var controller = new SessionsController(context);

            var answerIds = new List<long>() { 1, 2, 9, 13, 17 };

            var result = Assert.Throws<ValidationException>(() => controller.AddSession(new SelectionsDto() { AnswerIds = answerIds }));
            Assert.That(result.Message, Is.EqualTo("Each question can have only one answer!"));
        }
    }
}
