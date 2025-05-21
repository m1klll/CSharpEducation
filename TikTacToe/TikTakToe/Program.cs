namespace TikTacToe;

class Program
{
    static void Main(string[] args)
    {
        const string GAME_START = "Хотите сыграть в игру? y/n: ";
        
        Console.Write(GAME_START);
        {
            while (Console.ReadLine() == "y")
            {
                Game game = new Game();
                
                string winner = game.PlayGame();
                
                if (winner == Game.PLAYER_X || winner == Game.PLAYER_O)
                {
                    Console.WriteLine($"Победил игрок {winner}!");
                    Console.Write(GAME_START);
                }
                else
                {
                    Console.WriteLine("Ничья!");
                    Console.Write(GAME_START);
                }
            }
        }
    }
}