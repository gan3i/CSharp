using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;

namespace RandomQuestions
{
    class Program
    {
        static void Main(string[] args)
        {

            //string allQuestions = File.ReadAllText("Questions.json");
            string allQuestions = System.IO.File.ReadAllText(@"C:\Questions\Questions.txt");

            var quizMasterQuestions = JsonConvert.DeserializeObject<QuizMasterQuestions>(allQuestions);
            int numberOfQuestions = quizMasterQuestions.results.Count;
            Random rand = new Random();
            int displayedCount = 0;
           while(displayedCount <= numberOfQuestions)
            {
                Questions questions = new Questions();
                int questionToAsk = rand.Next(0, numberOfQuestions);

                questions = quizMasterQuestions.results[questionToAsk];
                Console.WriteLine(questions.Question);

                List<string> options = questions.incorrect_answers;
                options.Add(questions.Correct_Answer);
                int displayedOption;
                List<string> randomOptions=options.OrderBy(x => Guid.NewGuid()).ToList();  
                foreach(string s in options)
                {
                   
                }                
                Console.ReadLine();
            }



        }
    }
}
