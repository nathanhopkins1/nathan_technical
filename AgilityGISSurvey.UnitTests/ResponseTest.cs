using AgilityGISSurvey.Business;
using AgilityGISSurvey.Domain.Models;
using AgilityGISSurvey.Dtos;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;

namespace AgilityGISSurvey.UnitTests
{
    [TestClass]
    public class ResponseTest
    {
        [TestMethod]
        public void TestDataSave()
        {
            var request = new SubmitResponseDto
            {
                Question1Answer = "a",
                Question2Answer = new string[] {"b"},
                Question3Answer = "c",
                Question4Answer = "d",
                Question5Answer = new string[] {"a", "b"}
            };

            var sr = new SurveyResponse(new DataContext(  "Data Source=ADDEVLPT-ASUS-2\\SQLSRV2019DEV;Initial Catalog=AgilitySurvey;Integrated Security=True;Persist Security Info=True;MultipleActiveResultSets=True;Pooling=False;Application Name=Agility Survey;"));

            var result = sr.SubmitResponse(request);

            Assert.AreEqual(true, result, "Could not save to database");
        }
    }
}