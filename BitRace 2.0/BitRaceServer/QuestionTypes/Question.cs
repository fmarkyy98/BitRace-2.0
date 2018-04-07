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
        public Dictionary<char, string>  OptionalAnswers
        {
            get
            {
                return optionalAnswers;
            }
            set
            {
                optionalAnswers = value;
            }
        }
        protected List<int> keysOfSelectedIncorrectAnsver = new List<int>();

        public int Id { get { return id; } }

        public Question(int id, string text, Dictionary<char, string> optionalAnswers)
        {
            this.id = id;
            this.text = text;
            this.optionalAnswers = new Dictionary<char, string>(optionalAnswers);
            this.keysOfSelectedIncorrectAnsver = new List<int>();
        }

        public Question()
        {
            this.optionalAnswers = new Dictionary<char, string>(optionalAnswers);
            this.keysOfSelectedIncorrectAnsver = new List<int>();
        }

        internal string CaracterOfCorrectAnsver()
        {
            foreach (KeyValuePair<char, string> answer in optionalAnswers)
            {
               if( MSSQLConnector.IsCorrectAnswer(this.id, answer.Key))
                {
                    return answer.Value;
                }
            }
            throw new MissingFieldException("This question doesn't bind to any correct ansver.");
        }
    }
}
