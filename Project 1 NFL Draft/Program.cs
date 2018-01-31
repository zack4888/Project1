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
            string[,] NFL_PLayers = //these are all orginized in columns. all quarterbacks are in the first column and so on. 
                {
                {"Mason Rudolph","Saquon Barkley","Courtland Sutton","Maurice Hurst","Joshua Jackson","Mark Andrews","Roquan Smith","Orlando Brown" },
                {"Lamar Jackson","Derrius Guice","James Washinton","Vita Vea","Derwin James","Dallas Goedert","Termaine Edmunds","Kolton Miller"},
                {"Josh Rosen","Bryce Love","Marcell Ateman","Taven Bryan","Denzel Ward","Jaylen Samuels","Kendall Joseph","Chukwuma Okorafor"},
                {"Sam Darnold","Ronald Jones II","Anthony Miller","Da'Ron Payne","Minkah Fitzoatrick","Mike Gesicki","Dorian O'Daniel","Connor Williams"},
                {"Baker MayField","Damien Harris","Calvin Ridley","Harrison Phillips","Isaiah Oliver","Troy Fumagalli","Malik Jefferson","Mike McGlinchey"}
                };
            int[,] Salaries =
            {
                {26400100,24500100,23400000,26200300,24000000,27800900,22900300,23000000},
                {23300100,19890200,21900300,22000000,22500249,21000800,19000590,20000000},
                {17420300,18700800,19300230,16000000,20000100,17499233,18000222,19400000},
                {13100145,15000000,13400230,18000000,16000200,27900200,12999999,16200700},
                {10300000,11600400,10000000,13000000,11899999,14900333,10000100,15900000},
                {0,0,0,0,0,0,0,0 }
            };
            String[,] College =
            {
                {"Oklahoma State","Penn State","Southern Methodist","Michigan","Iowa","Oklahoma","Georgia","Oklahoma"},
                {"Louisville","LSU","Oklahoma State","Washington","Florida State","So. Dakota State","Virginia Tech0","UCLA"},
                {"UCLA","Stanford","Oklahoma State","Florida","Ohio State","NC State","Clemson","Western Michigan"},
                {"Southern California","Southern California","Memphis","Alabama","Alabama","Penn State","Clemson","Texas"},
                {"Oklahoma","Alabama","Alabama","Stanford","Colorado","Wisconsin","Texas","Notre Dame"},
            };



            while (true)
            {


                Dictionary<string, int> PlayersChosen = new Dictionary<string, int>();
                List<string> Yellow = new List<string>();
                List<string> Red = new List<string>();
                ConsoleKeyInfo SentinalKey;
                int SentinalValue = 0;
                float YourMoney = 95000000;
                ConsoleKeyInfo end;



                WelcomeScreen();

                Console.SetWindowSize(185, 55);

                while (SentinalValue < 5)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    foreach (var t in Titles)
                    {

                        Console.Write(" {0,-21}", t);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    YourMoney = Choosing(NFL_PLayers, College, Salaries, Yellow, Red, YourMoney, PlayersChosen);
                    SentinalValue++;
                    if (SentinalValue < 5)
                    {
                        while (true)
                        {
                            Console.WriteLine("Would you like to choose another player?[Y/N]");
                            SentinalKey = Console.ReadKey();
                            if (SentinalKey.Key == ConsoleKey.N)
                            {
                                SentinalValue = 5;
                                break;
                            }
                            else if (SentinalKey.Key != ConsoleKey.Y)
                            {
                                Console.WriteLine("Invalid option");
                            }
                            else break;
                        }
                    }
                    else
                    { SentinalValue = 5; }

                }
                end = Output(Red, YourMoney, NFL_PLayers, Salaries);
                if (end.Key == ConsoleKey.N)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }
            
        }
        static float Choosing(string[,] NFL_PLayers, string[,] College, int[,] Salaries, List<string> Yellow, List<string> Red, float YourMoney, Dictionary<string, int> PlayersChosen)
        {
            int indexing= 66;
            int indexing2= 66;
            string Player = "";
            int Sentinal = 0;
            
            PrintingAll(NFL_PLayers, College, Salaries, Yellow, Red, YourMoney);
            while (Sentinal != 1)
            {
               
                int Checking = 0;


                Console.BackgroundColor = ConsoleColor.White;
                if (YourMoney < 10000000)
                {
                    Console.WriteLine(" You Do not have enough Money to draft any player");
                    Console.WriteLine("press any Key to continue:");
                    Console.ReadKey();
                    break;
                }
                Console.Write("\n You have ${0:n0}\n You have spent {1:c0}\n Please choose the number of a player: ", YourMoney,95000000 - YourMoney);
                Player = Console.ReadLine();
                foreach (var i in Red)
                {
                    if (Player == i)
                    {
                        Checking = 1;
                    }
                }
                if (Checking == 0)
                {



                    try
                    {
                        indexing = Convert.ToInt32(Convert.ToString(Player[0]));
                        indexing2 = Convert.ToInt32(Convert.ToString(Player[1]));
                        PlayersChosen.Add(NFL_PLayers[indexing, indexing2], Salaries[indexing, indexing2]);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid option");
                    }
                   
                    if (indexing >= 0)
                    {
                        if (indexing <= 4)
                        {
                            if (indexing2 <= 7)
                            {
                                if (indexing2 >= 0)
                                {
                                    if (YourMoney > Salaries[indexing, indexing2])
                                    {
                                        Sentinal = 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You do not have enough money to draft this player");
                                        Console.WriteLine("Press any key to continue");
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                    }

                    
                    
                    
                }
                else
                {
                    Console.WriteLine("You've already chosen that player. please choose another player.");
                }

            }
            if (Sentinal == 1)
            {


                Red.Add(Player);
                YourMoney = YourMoney - Salaries[indexing, indexing2];
                Console.WriteLine("You chose {0} for {1:c0}", NFL_PLayers[indexing, indexing2], Salaries[indexing, indexing2]);
            }
                return YourMoney;

            
        }
        static void Line()
        {
           
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("\n{0,184}"," ");
        }
        static void Printing<T>( T[,] arrayName,int lineNumber,int First,List<string> Yellow,List<string> Red)
        {
            Console.Write("\n");
            ConsoleColor CurrentColor = ConsoleColor.Green;

            for (int i = 0; i < 8; i++)
            {
                foreach (var z in Yellow)
                {
                    if (lineNumber.ToString() + i.ToString() == z)
                    {
                        CurrentColor = ConsoleColor.Yellow;
                    }
                }
                foreach (var p in Red)
                {
                    if (lineNumber.ToString() + i.ToString() == p)
                    {
                        CurrentColor = ConsoleColor.Red;
                    }
                }
                if (First == 1)
                {
                    Console.BackgroundColor = CurrentColor;
                    Console.Write(" {2}{1} {0,-18}", arrayName[lineNumber, i],i,lineNumber);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                
                else
                {
                    if (First == 2)
                    {
                        Console.BackgroundColor = CurrentColor;
                        Console.Write(" {0:c0}          ", arrayName[lineNumber, i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = CurrentColor;
                        Console.Write(" {0,-21}", arrayName[lineNumber, i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                }
                CurrentColor = ConsoleColor.Green;
            }
            
        }
        static void PrintingAll(string[,] NFL_PLayers,string[,] College,int[,] Salaries,List<string> Yellow,List<string> Red,float YourMoney)
        {
            for (int t = 0; t < 5; t++)
            {

                for (int i = 0; i < 8; i++)
                {
                    if (YourMoney < Salaries[t, i])
                    {
                        Yellow.Add(t.ToString() + i.ToString());
                    }
                }
            }
            for (int i = 0; i < 5;i++)
            {
                Line();
                Printing<string>(NFL_PLayers, i,1,Yellow,Red);
                Printing<string>(College, i,0,Yellow,Red);
                Printing<int>(Salaries, i,2,Yellow,Red);
                
            }
            Line();
        }
        static void WelcomeScreen()
        {
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Welcome to the NFL Draft Program");
            Console.WriteLine("You are allowed to draft up to 5 Players of any Position");
            Console.WriteLine("You only have 95 Million Dolalrs to draft your players");
            Console.WriteLine("If you draft 3 players from the #1 #2 or #3 spot and spend less than 45 Million That will be considered a great Draft!");
            Console.WriteLine("If the Player is green you can choose that player, if the player is red you have already chosen them and if the player is yellow you cannot afford that palyer.");
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadKey();
            Console.Clear();

        }
        static ConsoleKeyInfo Output(List<string> Red,float YourMoney,string[,] NFL_Players,int[,] Salaries)
        {
            ConsoleKeyInfo end;
            int indexing;
            int indexing2;
            int GoodPicks = 0;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("You Drafted:");
            foreach (var i in Red)
            {
                indexing = Convert.ToInt32(Convert.ToString(i[0]));
                indexing2 = Convert.ToInt32(Convert.ToString(i[1]));
                Console.WriteLine("{0} for {1} ",NFL_Players[indexing,indexing2], Salaries[indexing,indexing2]);
                if (indexing <= 3)
                {
                    GoodPicks++;
                }

            }
            if (GoodPicks >= 3)
            {
                if (YourMoney >= 30000000)
                {
                    Console.WriteLine("This was a cost effextive draft! Good Job!");
                }
            }
            Console.WriteLine("You spent a total of: {0:c0}",95000000 - YourMoney);
            Console.WriteLine("Would you like to Make another draft? (Y/N)");
            
            end = Console.ReadKey();

            while (end.Key != ConsoleKey.Y && end.Key != ConsoleKey.N)
            {
                end = Console.ReadKey();
            }
            
            return end;
            
        }
    }
}
