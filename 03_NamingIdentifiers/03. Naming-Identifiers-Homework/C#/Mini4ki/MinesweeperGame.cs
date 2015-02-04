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
            bool gameNotStarted = true;
            bool maxPointsReached = false;

            do
            {
                if (gameNotStarted)
                {
                    Console.WriteLine("Lets play Minesweeper. Try to find fields without detonating a bomb." +
                        " enter 'top' if you want to see the best players results, 'restart' to start the game, 'exit' if you want to quit the game!");
                    DrawPlayField(playField);
                    gameNotStarted = false;
                }

                Console.Write("Write row and column numbers: ");
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
                        DrawRanking(topPlayersScores);
                        break;
                    case "restart":
                        playField = GeneratePlayField();
                        bombsPositions = GenerateBombsPositions();
                        DrawPlayField(playField);
                        isDetonated = false;
                        gameNotStarted = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (bombsPositions[row, column] != '*')
                        {
                            if (bombsPositions[row, column] == '-')
                            {
                                ChangePlayerTurn(playField, bombsPositions, row, column);
                                pointsCounter++;
                            }

                            if (MAX_POINTS == pointsCounter)
                            {
                                maxPointsReached = true;
                            }
                            else
                            {
                                DrawPlayField(playField);
                            }
                        }
                        else
                        {
                            isDetonated = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid Command!\n");
                        break;
                }

                if (isDetonated)
                {
                    DrawPlayField(bombsPositions);
                    Console.Write("\nYou've died as a hero! Your scores are: {0}. " + "Enter your name: ", pointsCounter);
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
                    DrawRanking(topPlayersScores);

                    playField = GeneratePlayField();
                    bombsPositions = GenerateBombsPositions();
                    pointsCounter = 0;
                    isDetonated = false;
                    gameNotStarted = true;
                }

                if (maxPointsReached)
                {
                    Console.WriteLine("\nCongrats! You have been opened all cells without dying.");
                    DrawPlayField(bombsPositions);
                    Console.WriteLine("Your name: ");
                    string playerName = Console.ReadLine();
                    TotalScores playerScore = new TotalScores(playerName, pointsCounter);
                    topPlayersScores.Add(playerScore);
                    DrawRanking(topPlayersScores);
                    playField = GeneratePlayField();
                    bombsPositions = GenerateBombsPositions();
                    pointsCounter = 0;
                    maxPointsReached = false;
                    gameNotStarted = true;
                }
            }
            while (playerPosition != "exit");
            Console.Read();
        }

        private static void DrawRanking(List<TotalScores> points)
        {
            Console.WriteLine("\nScores:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, points[i].PlayerName, points[i].PlayerScore);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There are no scores yet!\n");
            }
        }

        private static void ChangePlayerTurn(char[,] playField, char[,] bombsPositions, int row, int column)
        {
            char bombsCount = CalculateScore(bombsPositions, row, column);
            bombsPositions[row, column] = bombsCount;
            playField[row, column] = bombsCount;
        }

        private static void DrawPlayField(char[,] board)
        {
            int rowsLength = board.GetLength(0);
            int columnLength = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rowsLength; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columnLength; j++)
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
            int rows = 5;
            int columns = 10;
            char[,] playField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            foreach (int number in randomNumbers)
            {
                int column = number / columns;
                int row = number % columns;
                if (row == 0 && number != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                playField[column, row - 1] = '*';
            }

            return playField;
        }

        private static void CalculateResultScore(char[,] playField)
        {
            int column = playField.GetLength(0);
            int row = playField.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (playField[i, j] != '*')
                    {
                        char resultScore = CalculateScore(playField, i, j);
                        playField[i, j] = resultScore;
                    }
                }
            }
        }

        private static char CalculateScore(char[,] playField, int row, int column)
        {
            int scoreCounter = 0;
            int rowsNumber = playField.GetLength(0);
            int columnsNumber = playField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playField[row - 1, column] == '*')
                {
                    scoreCounter++;
                }
            }

            if (row + 1 < rowsNumber)
            {
                if (playField[row + 1, column] == '*')
                {
                    scoreCounter++;
                }
            }

            if (column - 1 >= 0)
            {
                if (playField[row, column - 1] == '*')
                {
                    scoreCounter++;
                }
            }

            if (column + 1 < columnsNumber)
            {
                if (playField[row, column + 1] == '*')
                {
                    scoreCounter++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (playField[row - 1, column - 1] == '*')
                {
                    scoreCounter++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columnsNumber))
            {
                if (playField[row - 1, column + 1] == '*')
                {
                    scoreCounter++;
                }
            }

            if ((row + 1 < rowsNumber) && (column - 1 >= 0))
            {
                if (playField[row + 1, column - 1] == '*')
                {
                    scoreCounter++;
                }
            }

            if ((row + 1 < rowsNumber) && (column + 1 < columnsNumber))
            {
                if (playField[row + 1, column + 1] == '*')
                {
                    scoreCounter++;
                }
            }

            return char.Parse(scoreCounter.ToString());
        }
    }
}