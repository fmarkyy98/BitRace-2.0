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
        Player encestor;
        Socket connection;
        Thread thread;
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
            thread = new Thread(listener);
            thread.Start();
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
                        Question actualQuestion = Game1.Questions[encestor.IndexOfActualMainQuestion];
                        try { actualQuestion = Game1.Questions[encestor.IndexOfActualMainQuestion].ExtensionQuestions[encestor.IndexOfPrimaryExtensionQuestion]; }
                        catch (ArgumentOutOfRangeException) { }
                        try { actualQuestion = Game1.Questions[encestor.IndexOfActualMainQuestion].ExtensionQuestions[encestor.IndexOfPrimaryExtensionQuestion].ExtensionQuestions[encestor.IndexOfSecondaryExtensionQuestion]; }
                        catch (ArgumentOutOfRangeException) { }
                        try
                        {
                            if (MSSQLConnector.IsCorrectAnswer(actualQuestion.Id, char.Parse(splitedInput[2])))
                            {
                                if (encestor.IndexOfPrimaryExtensionQuestion == -1)
                                {
                                    //Encestor.AddCorrectlyAnsweredQuestionId(Game1.Questions[Encestor.IndexOfActualMainQuestion].Id);
                                    encestor.AddCorrectlyAnsweredQuestionId(actualQuestion.Id);
                                    encestor.IndexOfActualMainQuestion++;
                                }
                                else if (encestor.IndexOfSecondaryExtensionQuestion == -1)
                                {
                                    //Encestor.AddCorrectlyAnsweredQuestionId(Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[Encestor.IndexOfPrimaryExtensionQuestion].Id);
                                    encestor.IndexOfPrimaryExtensionQuestion = -1;
                                }
                                else
                                {
                                    //Encestor.AddCorrectlyAnsweredQuestionId(Game1.Questions[Encestor.IndexOfActualMainQuestion].ExtensionQuestions[Encestor.IndexOfPrimaryExtensionQuestion].ExtensionQuestions[Encestor.IndexOfSecondaryExtensionQuestion].Id);
                                    encestor.IndexOfSecondaryExtensionQuestion = -1;
                                }
                                encestor.AddCorrectlyAnsweredQuestionId(actualQuestion.Id);
                            }
                            else
                            {
                                if (encestor.IndexOfPrimaryExtensionQuestion == -1)
                                {
                                    while (encestor.CorrectlyAnsveredQuestionIds.Contains(Game1.Questions[encestor.IndexOfActualMainQuestion].ExtensionQuestions[++encestor.IndexOfPrimaryExtensionQuestion].Id)) ;
                                }
                                else if (encestor.IndexOfSecondaryExtensionQuestion == -1)
                                {
                                    while (encestor.CorrectlyAnsveredQuestionIds.Contains(Game1.Questions[encestor.IndexOfActualMainQuestion].ExtensionQuestions[encestor.IndexOfPrimaryExtensionQuestion].ExtensionQuestions[++encestor.IndexOfSecondaryExtensionQuestion].Id)) ;
                                }
                                //else
                                //{
                                //    //SKYP
                                //}
                            }
                        }
                        catch (ArgumentException)
                        {
                            SendData($"question;Game Finished;-;-;-;-");
                            thread.Abort();
                        }
                        output = $"{Game1.Questions[encestor.IndexOfActualMainQuestion].Text};{String.Join(";", Game1.Questions[encestor.IndexOfActualMainQuestion].OptionalAnswers)}";
                        try { output = $"{Game1.Questions[encestor.IndexOfActualMainQuestion].ExtensionQuestions[encestor.IndexOfPrimaryExtensionQuestion].Text};{String.Join(";", Game1.Questions[encestor.IndexOfActualMainQuestion].ExtensionQuestions[encestor.IndexOfPrimaryExtensionQuestion].OptionalAnswers)}"; }
                        catch (ArgumentOutOfRangeException) { }
                        try { output = $"{Game1.Questions[encestor.IndexOfActualMainQuestion].ExtensionQuestions[encestor.IndexOfPrimaryExtensionQuestion].ExtensionQuestions[encestor.IndexOfSecondaryExtensionQuestion].Text};{String.Join(";", Game1.Questions[encestor.IndexOfActualMainQuestion].ExtensionQuestions[encestor.IndexOfPrimaryExtensionQuestion].ExtensionQuestions[encestor.IndexOfSecondaryExtensionQuestion].OptionalAnswers)}"; }
                        catch (ArgumentOutOfRangeException) { }
                        SendData($"question;{output}");
                    }
                }
                catch (SocketException)
                {

                }
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
            this.encestor = player;
        }
    }
}
