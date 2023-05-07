using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Personality.Model
{
    public class PersonalityContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Selection> Selections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("Personality");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(new List<Question>()
            {
                new Question()
                {
                    Id = 1,
                    Text = "You’re really busy at work and a colleague is telling you their life story and personal woes. You:"
                },
                new Question()
                {
                    Id = 2,
                    Text = "You’ve been sitting in the doctor’s waiting room for more than 25 minutes. You:"
                },
                new Question()
                {
                    Id = 3,
                    Text = "You’re having an animated discussion with a colleague regarding a project that you’re in charge of. You:"
                },
                new Question()
                {
                    Id = 4,
                    Text = "You crack a joke at work, but nobody seems to have noticed. You:"
                },
                new Question()
                {
                    Id = 5,
                    Text = "During dinner, the discussion moves to a subject about which you know nothing at all. You:"
                }
            });

            modelBuilder.Entity<Answer>().HasData(new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    Text = "Don’t dare to interrupt them",
                    Value = 0,
                    QuestionId = 1
                },
                new Answer()
                {
                    Id = 2,
                    Text = "Think it’s more important to give them some of your time; work can wait",
                    Value = 1,
                    QuestionId = 1
                },
                new Answer()
                {
                    Id = 3,
                    Text = "Listen, but with only with half an ear",
                    Value = 2,
                    QuestionId = 1
                },
                new Answer()
                {
                    Id = 4,
                    Text = "Interrupt and explain that you are really busy at the moment",
                    Value = 3,
                    QuestionId = 1
                }
            });

            modelBuilder.Entity<Answer>().HasData(new List<Answer>()
            {
                new Answer()
                {
                    Id = 5,
                    Text = "Look at your watch every two minutes",
                    Value = 1,
                    QuestionId = 2
                },
                new Answer()
                {
                    Id = 6,
                    Text = "Bubble with inner anger, but keep quiet",
                    Value = 0,
                    QuestionId = 2
                },
                new Answer()
                {
                    Id = 7,
                    Text = "Explain to other equally impatient people in the room that the doctor is always running late",
                    Value = 2,
                    QuestionId = 2
                },
                new Answer()
                {
                    Id = 8,
                    Text = "Complain in a loud voice, while tapping your foot impatiently",
                    Value = 3,
                    QuestionId = 2
                }
            });

            modelBuilder.Entity<Answer>().HasData(new List<Answer>()
            {
                new Answer()
                {
                    Id = 9,
                    Text = "Don’t dare contradict them",
                    Value = 1,
                    QuestionId = 3
                },
                new Answer()
                {
                    Id = 10,
                    Text = "Think that they are obviously right",
                    Value = 0,
                    QuestionId = 3
                },
                new Answer()
                {
                    Id = 11,
                    Text = "Defend your own point of view, tooth and nail",
                    Value = 2,
                    QuestionId = 3
                },
                new Answer()
                {
                    Id = 12,
                    Text = "Continuously interrupt your colleague",
                    Value = 3,
                    QuestionId = 3
                }
            });

            modelBuilder.Entity<Answer>().HasData(new List<Answer>()
            {
                new Answer()
                {
                    Id = 13,
                    Text = "Think it’s for the best — it was a lame joke anyway",
                    Value = 0,
                    QuestionId = 4
                },
                new Answer()
                {
                    Id = 14,
                    Text = "Wait to share it with your friends after work",
                    Value = 1,
                    QuestionId = 4
                },
                new Answer()
                {
                    Id = 15,
                    Text = "Try again a bit later with one of your colleagues",
                    Value = 2,
                    QuestionId = 4
                },
                new Answer()
                {
                    Id = 16,
                    Text = "Keep telling it until they pay attention",
                    Value = 3,
                    QuestionId = 4
                }
            });

            modelBuilder.Entity<Answer>().HasData(new List<Answer>()
            {
                new Answer()
                {
                    Id = 17,
                    Text = "Don’t dare show that you don’t know anything about the subjecte",
                    Value = 3,
                    QuestionId = 5
                },
                new Answer()
                {
                    Id = 18,
                    Text = "Barely follow the discussion",
                    Value = 2,
                    QuestionId = 5
                },
                new Answer()
                {
                    Id = 19,
                    Text = "Ask lots of questions to learn more about it",
                    Value = 1,
                    QuestionId = 5
                },
                new Answer()
                {
                    Id = 20,
                    Text = "Change the subject of discussion",
                    Value = 0,
                    QuestionId = 5
                }
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
