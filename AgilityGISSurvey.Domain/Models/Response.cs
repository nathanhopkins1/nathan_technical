using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilityGISSurvey.Domain.Models
{
    [Table("Response")]
    public class Response
    {
        public int Id { get; set; }
        public virtual List<Answer> Answers { get; set; }

    }
}
