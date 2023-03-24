using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilityGISSurvey.Domain.Models
{
    [Table("Answer")]
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionAnswer { get; set; }

        public int ResponseId { get; set; }
    }
}
