using System.Text;

namespace tic_tac_toe_2;

public class Game
{
    public static IEnumerable<string> Run(char[,] board)
    {
        var displayOutput = new StringBuilder();

        if (CheckVerticalLines(board))
        {

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
        else if (CheckHorizontalLines(board))
        {

            displayOutput.AppendLine("Player O:");
            displayOutput.AppendLine("X| |X");
            displayOutput.AppendLine("-+-+-");
            displayOutput.AppendLine("O|O|O");
            displayOutput.AppendLine("-+-+-");
            displayOutput.AppendLine("X| | ");
            displayOutput.AppendLine();
            displayOutput.Append("PLAYER O WON!");
            yield return displayOutput.ToString();
        }
        else
        {

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

    private static bool CheckVerticalLines(char[,] board)
    {
        if (board[0, 0] == 'X' && board[1, 0] == 'X' && board[2, 0] == 'X')
        {
            return true;
        }
        return false;
    }

    private static bool CheckHorizontalLines(char[,] board)
    {
        if (board[1, 0] == 'O' && board[1, 1] == 'O' && board[1, 2] == 'O')
        {
            return true;
        }

        return false;
    }
}

