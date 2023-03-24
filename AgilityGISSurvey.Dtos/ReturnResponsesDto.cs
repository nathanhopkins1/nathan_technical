using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilityGISSurvey.Dtos
{
    public class ReturnResponsesDto
    {
        public int NumberOfRespondents { get; set; }
        public QuestionResultsDto Question1Results { get; set; }
        public QuestionResultsDto Question2Results { get; set; }
        public QuestionResultsDto Question3Results { get; set; }
        public QuestionResultsDto Question4Results { get; set; }
        public QuestionResultsDto Question5Results { get; set; }
    }
}
