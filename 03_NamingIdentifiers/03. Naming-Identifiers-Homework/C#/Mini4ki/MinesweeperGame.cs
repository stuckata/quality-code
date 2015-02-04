using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesweeperGame
{
    public class Minesweeper
    {
        public class TotalScores
        {
            private string playerName;
            private int playerScore;

            public TotalScores(string playerName, int playerScore)
            {
                this.PlayerName = playerName;
                this.PlayerScore = playerScore;
            }

            public TotalScores()
            {
            }

            public string PlayerName
            {
                get
                {
                    return this.playerName;
                }

                set
                {
                    this.playerName = value;
                }
            }

            public int PlayerScore
            {
                get
                {
                    return this.playerScore;
                }

                set
                {
                    this.playerScore = value;
                }
            }
        }

        private static void Main()
        {
            const int MAX_POINTS = 35;
            string playerPosition = string.Empty;
            char[,] playField = GeneratePlayField();
            char[,] bombsPositions = GenerateBombsPositions();
            int pointsCounter = 0;
            bool isDetonated = false;
            List<TotalScores> topPlayersScores = new List<TotalScores>(6);
            int row = 0;
            int column = 0;
            bool flag = true;
            bool maxPointsReached = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine("Lets play Minesweeper. Try to find fields without detonating a bomb." +
                        " enter 'top' if you want to see the best players results, 'restart' to start the game, 'exit' if you want to quit the game!");
                    dumpp(playField);
                    flag = false;
                }

                Console.Write("Daj red i kolona : ");
                playerPosition = Console.ReadLine().Trim();
                if (playerPosition.Length >= 3)
                {
                    if (int.TryParse(playerPosition[0].ToString(), out row) && int.TryParse(playerPosition[2].ToString(), out column)
                        && row <= playField.GetLength(0) && column <= playField.GetLength(1))
                    {
                        playerPosition = "turn";
                    }
                }

                switch (playerPosition)
                {
                    case "top":
                        klasacia(topPlayersScores);
                        break;
                    case "restart":
                        playField = GeneratePlayField();
                        bombsPositions = GenerateBombsPositions();
                        dumpp(playField);
                        isDetonated = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombsPositions[row, column] != '*')
                        {
                            if (bombsPositions[row, column] == '-')
                            {
                                tisinahod(playField, bombsPositions, row, column);
                                pointsCounter++;
                            }

                            if (MAX_POINTS == pointsCounter)
                            {
                                maxPointsReached = true;
                            }
                            else
                            {
                                dumpp(playField);
                            }
                        }
                        else
                        {
                            isDetonated = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isDetonated)
                {
                    dumpp(bombsPositions);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", pointsCounter);
                    string niknejm = Console.ReadLine();
                    TotalScores t = new TotalScores(niknejm, pointsCounter);
                    if (topPlayersScores.Count < 5)
                    {
                        topPlayersScores.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayersScores.Count; i++)
                        {
                            if (topPlayersScores[i].PlayerScore < t.PlayerScore)
                            {
                                topPlayersScores.Insert(i, t);
                                topPlayersScores.RemoveAt(topPlayersScores.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayersScores.Sort((TotalScores r1, TotalScores r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    topPlayersScores.Sort((TotalScores r1, TotalScores r2) => r2.PlayerScore.CompareTo(r1.PlayerScore));
                    klasacia(topPlayersScores);

                    playField = GeneratePlayField();
                    bombsPositions = GenerateBombsPositions();
                    pointsCounter = 0;
                    isDetonated = false;
                    flag = true;
                }

                if (maxPointsReached)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    dumpp(bombsPositions);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    TotalScores to4kii = new TotalScores(imeee, pointsCounter);
                    topPlayersScores.Add(to4kii);
                    klasacia(topPlayersScores);
                    playField = GeneratePlayField();
                    bombsPositions = GenerateBombsPositions();
                    pointsCounter = 0;
                    maxPointsReached = false;
                    flag = true;
                }
            }
            while (playerPosition != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void klasacia(List<TotalScores> to4kii)
        {
            Console.WriteLine("\nTo4KI:");
            if (to4kii.Count > 0)
            {
                for (int i = 0; i < to4kii.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, to4kii[i].PlayerName, to4kii[i].PlayerScore);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void tisinahod(char[,] POLE, char[,] BOMBI, int RED, int KOLONA)
        {
            char kolkoBombi = kolko(BOMBI, RED, KOLONA);
            BOMBI[RED, KOLONA] = kolkoBombi;
            POLE[RED, KOLONA] = kolkoBombi;
        }

        private static void dumpp(char[,] board)
        {
            int RRR = board.GetLength(0);
            int KKK = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < RRR; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < KKK; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GeneratePlayField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] GenerateBombsPositions()
        {
            int Редове = 5;
            int Колони = 10;
            char[,] игрално_поле = new char[Редове, Колони];

            for (int i = 0; i < Редове; i++)
            {
                for (int j = 0; j < Колони; j++)
                {
                    игрално_поле[i, j] = '-';
                }
            }

            List<int> r3 = new List<int>();
            while (r3.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!r3.Contains(asfd))
                {
                    r3.Add(asfd);
                }
            }

            foreach (int i2 in r3)
            {
                int kol = i2 / Колони;
                int red = i2 % Колони;
                if (red == 0 && i2 != 0)
                {
                    kol--;
                    red = Колони;
                }
                else
                {
                    red++;
                }

                игрално_поле[kol, red - 1] = '*';
            }

            return игрално_поле;
        }

        private static void smetki(char[,] pole)
        {
            int kol = pole.GetLength(0);
            int red = pole.GetLength(1);

            for (int i = 0; i < kol; i++)
            {
                for (int j = 0; j < red; j++)
                {
                    if (pole[i, j] != '*')
                    {
                        char kolkoo = kolko(pole, i, j);
                        pole[i, j] = kolkoo;
                    }
                }
            }
        }

        private static char kolko(char[,] r, int rr, int rrr)
        {
            int brojkata = 0;
            int reds = r.GetLength(0);
            int kols = r.GetLength(1);

            if (rr - 1 >= 0)
            {
                if (r[rr - 1, rrr] == '*')
                {
                    brojkata++;
                }
            }

            if (rr + 1 < reds)
            {
                if (r[rr + 1, rrr] == '*')
                {
                    brojkata++;
                }
            }

            if (rrr - 1 >= 0)
            {
                if (r[rr, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }

            if (rrr + 1 < kols)
            {
                if (r[rr, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr - 1 >= 0) && (rrr - 1 >= 0))
            {
                if (r[rr - 1, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr - 1 >= 0) && (rrr + 1 < kols))
            {
                if (r[rr - 1, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr + 1 < reds) && (rrr - 1 >= 0))
            {
                if (r[rr + 1, rrr - 1] == '*')
                {
                    brojkata++;
                }
            }

            if ((rr + 1 < reds) && (rrr + 1 < kols))
            {
                if (r[rr + 1, rrr + 1] == '*')
                {
                    brojkata++;
                }
            }

            return char.Parse(brojkata.ToString());
        }
    }
}