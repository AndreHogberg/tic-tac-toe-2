using System.Text;

namespace tic_tac_toe_2;

public class Game
{
    public static IEnumerable<string> Run(char[,] board)
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
        displayOutput.AppendLine("The game will start with player X");

        yield return displayOutput.ToString();
    }
}
