namespace TikTacToe;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Хотите сыграть в игру? y/n: ");
        string answer = Console.ReadLine();
        string[,] gameBoard = null;
        if (answer == "y")
        { 
            gameBoard = CreateGameBoard();
            string winner = PlayGame(gameBoard);
            Console.WriteLine($"Победил игрок {winner}!");
        }
    }

    static string[,] CreateGameBoard()
    {
        string[,] gameBoard = new string[3, 3];
        
        int rows = gameBoard.GetLength(0);
        int columns = gameBoard.GetLength(1);
        int count = 1;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                gameBoard[i, j] = Convert.ToString(count);
                count++;
            }
        }
        
        return gameBoard;
    }

    static void PrintGameBoard(string[,] gameBoard)
    {
        Console.WriteLine("-------------");
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            Console.Write("| ");
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                Console.Write(gameBoard[i, j] + " | ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("-------------");
    }

    static bool StepPlayer(string[,] gameBoard, string player, int[]playerSteps, int playerStepCount)
    {
        PrintGameBoard(gameBoard);
        Console.Write($"Ход {player}. Выберите свободное поле: ");
        string answer = Console.ReadLine();
        int row = (Convert.ToInt32(answer) - 1) / 3;
        int column = (Convert.ToInt32(answer) - 1) % 3;
        if (gameBoard[row, column] == "0" || gameBoard[row, column] == "X")
        {
            Console.WriteLine("Неверный ход!");
        }
        else
        {
            if (player == "X")
            {
                gameBoard[row, column] = "X";
                playerSteps[playerStepCount] = (row * 3 + column) + 1;
                if (CheckWinner(playerSteps))
                {
                    
                    return true;
                }
            }
            else
            {
                gameBoard[row, column] = "O";
                playerSteps[playerStepCount] = (row * 3 + column) + 1;
                if (CheckWinner(playerSteps))
                {
                    
                    return true;
                }
            }
        }
        return false;
    }

    static bool CheckWinner(int[] playerSteps)
    {
        int[][] winCombinations = new int[][]
        {
            new int[] {1, 2, 3},  // горизонталь верх
            new int[] {4, 5, 6},  // горизонталь середина
            new int[] {7, 8, 9},  // горизонталь низ

            new int[] {1, 4, 7},  // вертикаль левая
            new int[] {2, 5, 8},  // вертикаль средняя
            new int[] {3, 6, 9},  // вертикаль правая

            new int[] {1, 5, 9},  // диагональ \
            new int[] {3, 5, 7},  // диагональ /
        };

        foreach (var comb in winCombinations)
        {
            if (comb.All(step => playerSteps.Contains(step)))
            {
                return true;
            }
        }

        return false;
    }
    
    static string PlayGame(string[,] gameBoard)
    {
        // символ игрока
        string playerOne = "X";
        string playerTwo = "O";
        
        // победивший
        bool playerOneWinner = false; 
        bool playerTwoWinner = false;
        
        // шаги игрока
        int[] playerOneSteps = new int[5];
        int[] playerTwoSteps = new int[5];
        
        // количество шагов у игрока
        int stepCountPlayerOne = 0;
        int stepCountPlayerTwo = 0;
        
        while (true)
        {
            playerOneWinner = StepPlayer(gameBoard, playerOne, playerOneSteps, stepCountPlayerOne);
            
            if (playerOneWinner)
            {
                return "1";
            }
            
            stepCountPlayerOne++;
            
            playerTwoWinner = StepPlayer(gameBoard, playerTwo, playerTwoSteps, stepCountPlayerTwo);
            
            if (playerTwoWinner)
            {
                return "2";
            }
            
            stepCountPlayerTwo++;
        }
    }
}