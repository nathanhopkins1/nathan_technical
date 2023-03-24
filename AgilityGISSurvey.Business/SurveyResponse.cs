using AgilityGISSurvey.Domain.Models;
using AgilityGISSurvey.Dtos;
using System.Xml.Linq;

namespace AgilityGISSurvey.Business
{
    public class SurveyResponse
    {
        private readonly DataContext _data;
        public SurveyResponse(DataContext data)
        {
            _data = data;
        }

        public SurveyResponse()
        {
            
        }

        public bool SubmitResponse(SubmitResponseDto request)
        {
            try
            {
                var response = new Response
                {
                    Answers = new List<Answer>
                {
                    new Answer { QuestionNumber = 1, QuestionAnswer = request.Question1Answer },
                    new Answer { QuestionNumber = 3, QuestionAnswer = request.Question3Answer },
                    new Answer { QuestionNumber = 4, QuestionAnswer = request.Question4Answer },
                }
                };

                //add is multiple flag
                for (int i = 0; i < request.Question2Answer.Length; i++)
                {
                    var q2Answer = new Answer
                    {
                        QuestionNumber = 2,
                        QuestionAnswer = request.Question2Answer[i],
                        ResponseId = response.Id
                    };
                    response.Answers.Add(q2Answer);
                }

                for (int i = 0; i < request.Question5Answer.Length; i++)
                {
                    var q5Answer = new Answer
                    {
                        QuestionNumber = 5,
                        QuestionAnswer = request.Question5Answer[i],
                        ResponseId = response.Id
                    };
                    response.Answers.Add(q5Answer);
                }

                _data.Responses.Add(response);
                _data.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}