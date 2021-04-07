using System.Collections.Generic;
using AutoFixture;
using FCManagement.DAL.IMPL;
using FCManagement.Entities;

namespace FCManagement.IntegrationTests.Util
{
    public class FakeDbInitializer
    {
        public static void Initialize(FitnessDbContext context)
        {
            var fixture = new Fixture();

            var instructors = new List<Instructor>();
            //var questions = new List<Tests_CRUD_DAL.Entities.Question>();
            //var tests = new List<Tests_CRUD_DAL.Entities.Test>();
            //var testthemes = new List<Tests_CRUD_DAL.Entities.TestTheme>();

            for (int i = 0; i < 10; i++)
            {
                instructors.Add(fixture.Create<Instructor>());
                //answers.Add(fixture.Build<Tests_CRUD_DAL.Entities.Answer>().Without(x => x.Question).Without(x => x.QuestionId).Create());
                //questions.Add(fixture.Build<Tests_CRUD_DAL.Entities.Question>().Without(x => x.Answers).Without(x => x.Test).Without(x => x.TestId).Create());
                //tests.Add(fixture.Build<Tests_CRUD_DAL.Entities.Test>().Without(x => x.Questions).Without(x => x.TestThemeId).Without(x => x.TestTheme).Create());
                //testthemes.Add(fixture.Build<Tests_CRUD_DAL.Entities.TestTheme>().Without(x => x.Tests).Create());
            }

            context.Instructors.AddRange(instructors);
            //context.Questions.AddRange(questions);
            //context.Tests.AddRange(tests);
            //context.TestThemes.AddRange(testthemes);

            context.SaveChanges();
        }
    }
}