using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1_NFL_Draft
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Titles = { "Quarterback", "Running Back", "Wide-Reveiver", "Defensive Lineman", "Defensive-Back", "Tight Ends", "LineBacker's", "Offensive Tackles" };
            string[,] NFL_PLayers = //these are all orginized in columbs. all quarterbacks are in the first columb and so on. 
                {
                {"Mason Rudolph","Saquon Barkley","Courtland Sutton","Maurice Hurst","Joshua Jackson","Mark Andrews","Roquan Smith","Orlando Brown" },
                {"Lamar Jackson","Derrius Guice","James Washinton","Vita Vea","Derwin James","Dallas Goedert","Termaine Edmunds","Kolton Miller"},
                {"Josh Rosen","Bryce Love","Marcell Ateman","Taven Bryan","Denzel Ward","Jaylen Samuels","Kendall Joseph","Chukwuma Okorafor"},
                {"Sam Darnold","Ronald Jones II","Anthony Miller","Da'Ron Payne","Minkah Fitzoatrick","Mike Gesicki","Dorian O'Daniel","Connor Williams"},
                {"Baker MayField","Damien Harris","Calvin Ridley","Harrison Phillips","Isaiah Oliver","Troy Fumagalli","Malik Jefferson","Mike McGlinchey"}
                };
            int[,] Salaries =
            {
                {26400100,24500100,23400000,26200300,24000000,27800900,2200300,23000000},
                {23300100,19890200,21900300,22000000,22500249,21000800,19000590,20000000},
                {17420300,18700800,19300230,16000000,20000100,17499233,18000222,19400000},
                {13100145,15000000,134000230,18000000,16000200,27900200,12999999,16200700},
                {10300000,11600400,10000000,13000000,11899999,14900333,10000100,15900000},
            };
            String[,] College =
            {
                {"Oklahoma State","Penn State","Southern Methodist","Michigan","Iowa","Oklahoma","Georgia","Oklahoma"},
                {"Louisville","LSU","Oklahoma State","Washington","Florida State","So. Dakota State","Virginia Tech0","UCLA"},
                {"UCLA","Stanford","Oklahoma State","Florida","Ohio State","NC State","Clemson","Western Michigan"},
                {"Southern California","Southern California","Memphis","Alabama","Alabama","Penn State","Clemson","Texas"},
                {"Oklahoma","Alabama","Alabama","Stanford","Colorado","Wisconsin","Texas","Notre Dame"},
            };
            Dictionary<string, int> PlayersChosen = new Dictionary<string, int>();
            string Player;
            int indexing;
            int indexing2;


            Console.SetWindowSize(185, 55);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            foreach (var t in Titles)
            {
                
                Console.Write(" {0,-21}", t);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Cyan ;
            }
            PrintingAll(NFL_PLayers, College, Salaries);
            Line();
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("\n Please choose the number of a player: ");
            Player = Console.ReadLine();
            indexing = Player[0];
            indexing2 = Player[1];
            Console.Write("{0},{1}",indexing, indexing2);
            Console.Read();
            PlayersChosen.Add(NFL_PLayers[indexing, indexing2],Salaries[indexing,indexing2]);
            Console.ReadLine();
        }
        static void Line()
        {
           
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n{0,184}"," ");
        }
        static void Printing<T>( T[,] arrayName,int lineNumber,int First)
        {
            Console.Write("\n");
            for (int i = 0; i < 8; i++)
            {
                if (First == 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" {2}{1} {0,-18}", arrayName[lineNumber, i],i,lineNumber);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" {0,-21}", arrayName[lineNumber, i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
            }
            
        }
        static void PrintingAll(string[,] NFL_PLayers,string[,] College,int[,] Salaries)
        {
            for (int i = 0; i < 5;i++)
            {
                Line();
                Printing<string>(NFL_PLayers, i,1);
                Printing<string>(College, i,0);
                Printing<int>(Salaries, i,0);
            }
        }
    }
}
