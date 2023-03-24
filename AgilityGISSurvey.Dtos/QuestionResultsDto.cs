using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilityGISSurvey.Dtos
{
    public class QuestionResultsDto
    {
        public Choice A { get; set; }
        public Choice B { get; set; }
        public Choice C { get; set; }
        public Choice? D { get; set; }
    }
}
