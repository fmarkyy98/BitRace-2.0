using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static BitRaceServer.Controller;

namespace BitRaceServer
{
    class PlayerConnector
    {
        Player Encestor;
        Socket connection;
        string input;
        string output;
        bool isRead;
        bool IsRead { get { return isRead; } }

        public string Input
        {
            get
            {
                isRead = true;
                return input;
            }
        }
        public string Output { get { return output; } set { output = value; } }

        public PlayerConnector(Socket socket)
        {
            this.connection = socket;
            new Thread(listener).Start();
        }
        private void listener()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int recieveSize = connection.Receive(buffer);
                    string input = Encoding.ASCII.GetString(buffer, 0, recieveSize);
                    string[] splitedInput = input.Split(';');
                    if (input != this.input)
                    {
                        isRead = false;
                        this.input = input;
                        Question actualQuestion = Game1.Questions[Encestor.IndexOfActualMainQuestion];
                        try { actualQuestion = Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[Encestor.IndexOfPrimaryExtensionQuestion]; }
                        catch (IndexOutOfRangeException) { }
                        try { actualQuestion = Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[Encestor.IndexOfPrimaryExtensionQuestion].ExtensionQuestions[Encestor.IndexOfSecondaryExtensionQuestion]; }
                        catch (IndexOutOfRangeException) { }
                        if (MSSQLConnector.IsCorrectAnswer(actualQuestion.Id, char.Parse(splitedInput[2])))
                        {
                            if (Encestor.IndexOfPrimaryExtensionQuestion == -1)
                            {
                                //Encestor.AddCorrectlyAnsweredQuestionId(Game1.Questions[Encestor.IndexOfActualMainQuestion].Id);
                                Encestor.AddCorrectlyAnsweredQuestionId(actualQuestion.Id);
                                Encestor.IndexOfActualMainQuestion++;
                            }
                            else if (Encestor.IndexOfSecondaryExtensionQuestion == -1)
                            {
                                //Encestor.AddCorrectlyAnsweredQuestionId(Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[Encestor.IndexOfPrimaryExtensionQuestion].Id);
                                Encestor.IndexOfPrimaryExtensionQuestion = -1;
                            }
                            else
                            {
                                //Encestor.AddCorrectlyAnsweredQuestionId(Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[Encestor.IndexOfPrimaryExtensionQuestion].ExtensionQuestions[Encestor.IndexOfSecondaryExtensionQuestion].Id);
                                Encestor.IndexOfSecondaryExtensionQuestion = -1;
                            }
                            Encestor.AddCorrectlyAnsweredQuestionId(actualQuestion.Id);
                        }
                        else
                        {
                            if (Encestor.IndexOfPrimaryExtensionQuestion == -1)
                            {
                                while (Encestor.CorrectlyAnsveredQuestionIds.Contains(Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[++Encestor.IndexOfPrimaryExtensionQuestion].Id)) ;
                            }
                            else if (Encestor.IndexOfSecondaryExtensionQuestion == -1)
                            {
                                while (Encestor.CorrectlyAnsveredQuestionIds.Contains(Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[Encestor.IndexOfPrimaryExtensionQuestion].ExtensionQuestions[++Encestor.IndexOfSecondaryExtensionQuestion].Id)) ;
                            }
                            //else
                            //{
                            //    //SKYP
                            //}
                        }
                        output = $"{Game1.Questions[Encestor.IndexOfActualMainQuestion].Text};{String.Join(";", Game1.Questions[Encestor.IndexOfActualMainQuestion].OptionalAnswers)}";
                        try { output = $"{Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[Encestor.IndexOfPrimaryExtensionQuestion].Text};{String.Join(";", Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[Encestor.IndexOfPrimaryExtensionQuestion].OptionalAnswers)}"; }
                        catch (IndexOutOfRangeException) { }
                        try { output = $"{Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[Encestor.IndexOfPrimaryExtensionQuestion].ExtensionQuestions[Encestor.IndexOfSecondaryExtensionQuestion].Text};{String.Join(";", Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[Encestor.IndexOfPrimaryExtensionQuestion].ExtensionQuestions[Encestor.IndexOfSecondaryExtensionQuestion].OptionalAnswers)}"; }
                        catch (IndexOutOfRangeException) { }
                        SendData($"question;{output}");
                    }
                }
                catch { }
            }
        }

        public void SendData(string output)
        {
            this.output = output;
            byte[] data = Encoding.ASCII.GetBytes(this.output);
            connection.Send(data);
        }
        public void GetEncestorByReference(Player player)
        {
            this.Encestor = player;
        }
    }
}
