using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BitRaceServer.Enums;

namespace BitRaceServer
{
    abstract class Question
    {
        protected int id;
        protected string text;
        protected Difficulty difficulty;
        protected Dictionary<char, string> optionalAnswers;
        public Dictionary<char, string> OptionalAnswers
        {
            get
            {
                return new Dictionary<char, string>(this.optionalAnswers);
            }
            set
            {
                this.optionalAnswers = new Dictionary<char, string>(value);
            }
        }
        //protected List<int> keysOfSelectedIncorrectAnsver = new List<int>();

        public int Id { get { return id; } }
        public string Text { get { return text; } }

        public Question(int id, string text, Dictionary<char, string> optionalAnswers)
        {
            this.id = id;
            this.text = text;
            this.optionalAnswers = new Dictionary<char, string>(optionalAnswers);
        }

        public Question()
        {
            this.optionalAnswers = new Dictionary<char, string>(optionalAnswers);
        }

        internal string CaracterOfCorrectAnsver()
        {
            foreach (KeyValuePair<char, string> answer in optionalAnswers)
            {
                if (MSSQLConnector.IsCorrectAnswer(this.id, answer.Key))
                {
                    return answer.Value;
                }
            }
            throw new MissingFieldException("This question doesn't bind to any correct ansver.");
        }
    }
}
