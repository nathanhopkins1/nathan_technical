using AgilityGISSurvey.Business;
using AgilityGISSurvey.Domain.Models;
using AgilityGISSurvey.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgilityGISSurvey.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly DataContext _data;
        private readonly SurveyResponse _surveyResponse;
       // private readonly IConfiguration _configuration;
        public ResponseController(/*IConfiguration configuration,*/ DataContext data)
        {
            //_configuration = configuration;
            _data = data;
            _surveyResponse = new SurveyResponse(data);
        }

        [HttpGet]
        public ActionResult GetResponses()
        {
            var returnResponse = new ReturnResponsesDto();

            var responses = _data.Responses.ToList();

            var numberOfRespondents = responses.Count;

            for (int i = 1; i <= 5; i++)
            {
                decimal test = (decimal)7 / (decimal)25 * (decimal)100;
                decimal x = (decimal)_data.Answers.Where(x => x.QuestionNumber == i && x.QuestionAnswer == "a").ToList().Count / (decimal)numberOfRespondents * (decimal)100;
                var temp = new QuestionResultsDto()
                {
                    A = new Choice() { NumberOfRespondents = ((decimal)_data.Answers.Where(x => x.QuestionNumber == i && x.QuestionAnswer == "a").ToList().Count / (decimal)numberOfRespondents * (decimal)100).ToString("F") },
                    B = new Choice() { NumberOfRespondents = ((decimal)_data.Answers.Where(x => x.QuestionNumber == i && x.QuestionAnswer == "b").ToList().Count / (decimal)numberOfRespondents * (decimal)100).ToString("F") },
                    C = new Choice() { NumberOfRespondents = ((decimal)_data.Answers.Where(x => x.QuestionNumber == i && x.QuestionAnswer == "c").ToList().Count / (decimal)numberOfRespondents * (decimal)100).ToString("F") },
                    D = new Choice() { NumberOfRespondents = ((decimal)_data.Answers.Where(x => x.QuestionNumber == i && x.QuestionAnswer == "d").ToList().Count / (decimal)numberOfRespondents * (decimal)100).ToString("F") }
                };

                switch (i)
                {
                    case 1:
                        returnResponse.Question1Results = temp;
                        break;
                    case 2:
                        returnResponse.Question2Results = temp;
                        break;
                    case 3:
                        returnResponse.Question3Results = temp;
                        break;
                    case 4:
                        returnResponse.Question4Results = temp;
                        break;
                    case 5:
                        returnResponse.Question5Results = temp;
                        break;
                    default:
                        break;
                }
            }

            returnResponse.NumberOfRespondents = numberOfRespondents;
            return Ok(returnResponse);
        }

        [HttpPost("submit-response")]
        public ActionResult SubmitResponse(SubmitResponseDto request)
        {
            var result =  _surveyResponse.SubmitResponse(request);

            return Ok(new { Success = result} );
        }
    }
}
