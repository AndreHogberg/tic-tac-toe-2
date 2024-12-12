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
            BuildBoard(displayOutput, board);
            displayOutput.AppendLine();
            displayOutput.Append("PLAYER X WON!");
            yield return displayOutput.ToString();
        }
        else if (CheckHorizontalLines(board))
        {

            displayOutput.AppendLine("Player O:");
            BuildBoard(displayOutput, board);
            displayOutput.AppendLine();

            displayOutput.Append("PLAYER O WON!");
            yield return displayOutput.ToString();
        }
        else if (CheckDiagonalLines(board))
        {
            displayOutput.AppendLine("Player O:");
            BuildBoard(displayOutput, board);
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

    private static bool CheckDiagonalLines(char[,] board)
    {
        if (board[0, 0] == 'O' && board[1, 1] == 'O' && board[2, 2] == 'O')
        {
            return true;
        }
        if (board[0, 2] == 'O' && board[1, 1] == 'O' && board[2, 0] == 'O')
        {
            return true;
        }

        return false;
    }

    private static void BuildBoard(StringBuilder stringBuilder, char[,] board)
    {

        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (col != board.GetLength(1) - 1)
                {
                    stringBuilder.Append(board[row, col]);
                    stringBuilder.Append('|');
                }
                else
                {
                    stringBuilder.Append($"{board[row, col]}");
                }
                
            }
            stringBuilder.AppendLine();
            if (row != board.GetLength(0) - 1)
            {
                stringBuilder.AppendLine("-+-+-");
            }
        }
    }
    
    private static bool CheckVerticalLines(char[,] board)
    {
        for (var col = 0; col < board.GetLength(0); col++)
        {
            if (board[0, col] == 'X' && board[1, col] == 'X' && board[2, col] == 'X')
            {
                return true;
            }
        }
        return false;
    }

    private static bool CheckHorizontalLines(char[,] board)
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            if (board[row, 0] == 'O' && board[row, 1] == 'O' && board[row, 2] == 'O')
            {
                return true;
            }
        }

        return false;
    }
}

