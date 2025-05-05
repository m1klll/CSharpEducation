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
            PlayGame(gameBoard);
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

    static void StepPlayer(string[,] gameBoard, string player, int[][]playerSteps)
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
            }
            else
            {
                gameBoard[row, column] = "O";
            }
        }
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
        int[][] playerOneSteps = new int[5][];
        int[][] playerTwoSteps = new int[5][];
        
        while (playerOneWinner != true || playerTwoWinner != true)
        {
            StepPlayer(gameBoard, playerOne, playerOneSteps);
            StepPlayer(gameBoard, playerTwo, playerTwoSteps);
            
        }

        return "winner x";
    }
}