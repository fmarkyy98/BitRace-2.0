using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static BitRaceServer.Enums;
using static BitRaceServer.Enums.ConnectionState;

namespace BitRaceServer
{
    class Controller
    {
        static Game game1 = new Game(1, 3, 3);
        public static Game Game1 { get { return new Game(game1); } }

        static ConnectionState sqlState;

        static List<Socket> clientsGlobal = new List<Socket>();

        static void IncomingSocketManageing()
        {
            // connectedek ellenorzese, majd a hibasakat
            while (true)
            {
                List<Socket> clients;
                lock (clientsGlobal)
                {
                    clients = clientsGlobal.Where(x => x.Connected).ToList();
                    clientsGlobal.RemoveAll(x => !clients.Contains(x));
                }

                if (clients.Count == 0)
                    continue;

                List<Socket> error = new List<Socket>();
                Socket.Select(clients, null, error, 1000);
                foreach (var s in error)
                {
                    clients.Remove(s);
                }

                //foreach (var client in clients)
                List<int> boundedIndexes = new List<int>();
                for (int i = 0; i < clients.Count; i++)
                {
                    if (boundedIndexes.Contains(i))
                    {
                        continue;
                    }
                    byte[] buffer = new byte[1024];
                    clients[i].ReceiveTimeout = 1000;
                    int recieveSize = 0;
                    try { recieveSize = clients[i].Receive(buffer); }
                    catch (SocketException)
                    {
                        continue;
                    }
                    if (recieveSize <= 0)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    string input = Encoding.ASCII.GetString(buffer, 0, recieveSize);
                    string[] splitedInput = input.Split(';');

                    if (splitedInput[0] == "mssql")
                    {
                        clients[i].Send(Encoding.ASCII.GetBytes("mssql;" + sqlState.ToString().ToLower()));
                    }
                    else if (splitedInput[0] == "register")
                    {
                        int indexOfCurrent = game1.Players.Select(x => x.Name).ToList().IndexOf(splitedInput[0]);
                        if (indexOfCurrent == -1)
                        {
                            game1.AddPlayer(splitedInput[1], clients[i]);
                        }
                        else
                        {
                            game1.Players[indexOfCurrent].Conect(clients[i]);
                        }
                        clients[i].Send(Encoding.ASCII.GetBytes($"question;{Game1.Questions[0].Text};{String.Join(";", Game1.Questions[0].OptionalAnswers)}"));
                        boundedIndexes.Add(i);
                    }
                }
            }
        }

        static void Main(string[] args)
        {


            Socket connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connection.Bind(new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 8912));
            connection.Listen(0);
            try
            {
                MSSQLConnector.BuildConnection(@"CNHEGYI\SQL2016", "BitRace");
                Controller.sqlState = building;
                Console.WriteLine("Connection was succesfully built.");
                Controller.sqlState = connected;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Controller.sqlState = disconnected;
            }
            Console.WriteLine("Started Listening at LocalHost:8912");
            new Thread(IncomingSocketManageing).Start();
            while (true)
            {
                Socket incoming = connection.Accept();
                lock (clientsGlobal)
                {
                    clientsGlobal.Add(incoming);
                }
            }
        }

    }
}
