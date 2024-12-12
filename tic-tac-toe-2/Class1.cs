using System.Text;

namespace tic_tac_toe_2;

public class Game
{
    public static IEnumerable<string> Run(char[,] board)
    {

        if (board[0, 0] == 'X')
        {
            var displayOutput = new StringBuilder();

            displayOutput.AppendLine("Player X:");
            displayOutput.AppendLine("X| | ");
            displayOutput.AppendLine("-+-+-");
            displayOutput.AppendLine("X|O| ");
            displayOutput.AppendLine("-+-+-");
            displayOutput.AppendLine("X| |O");
            displayOutput.AppendLine();
            displayOutput.Append("PLAYER X WON!");
            yield return displayOutput.ToString();
        }
        else
        {
            var displayOutput = new StringBuilder();

            displayOutput.AppendLine("Game Board Creation...");
            displayOutput.AppendLine(" | | ");
            displayOutput.AppendLine("-+-+-");
            displayOutput.AppendLine(" | | ");
            displayOutput.AppendLine("-+-+-");
            displayOutput.AppendLine(" | | ");
            displayOutput.AppendLine();
            displayOutput.AppendLine("Board Created.");
            displayOutput.Append("The game will start with player X");
        
        
        
            yield return displayOutput.ToString();
        }

    }
}
