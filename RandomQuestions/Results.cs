using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomQuestions
{
   public class Questions
    {
        public int QuestionId { get; set; }
        public string Category { get; set; }
        public string type { get; set; }
        public string Difficulty { get; set; }
        public string Question { get; set; }
        public string Correct_Answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }
}
