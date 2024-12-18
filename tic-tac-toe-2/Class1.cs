using System.Text;

namespace tic_tac_toe_2;

public class Game
{
    public static IEnumerable<string> Run(char[,] board)
    {
        var displayOutput = new StringBuilder();
        for (var turn = 0; turn <= 9; turn++)
        {
            if (turn == 0)
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
                displayOutput.Clear();
            }
            
            if (CheckVerticalLines(board, out var mark))
            {
                displayOutput.AppendLine($"Player {mark}:");

                BuildBoard(displayOutput, board);
                displayOutput.AppendLine();
                displayOutput.Append($"PLAYER {mark} WON!");
                yield return displayOutput.ToString();
                break;
            }
            if (CheckHorizontalLines(board, out mark))
            {
            
                displayOutput.AppendLine($"Player {mark}:");
                BuildBoard(displayOutput, board);
                displayOutput.AppendLine();
            
                displayOutput.Append($"PLAYER {mark} WON!");
                yield return displayOutput.ToString();
                break;
            }
            if (CheckDiagonalLines(board, out mark))
            {
                displayOutput.AppendLine($"Player {mark}:");
                BuildBoard(displayOutput, board);
                displayOutput.AppendLine();
            
                displayOutput.Append($"PLAYER {mark} WON!");
                yield return displayOutput.ToString();
                break;
            }

            if (CheckDraw(board))
            {
                var player = IsXTurn(board) ? "X" : "O";
                
                displayOutput.AppendLine($"Player {player}:");
                BuildBoard(displayOutput, board);
                displayOutput.AppendLine();
                displayOutput.Append("THE GAME ENDS WITH A DRAW!");
                yield return displayOutput.ToString();
                break;
            }
            
            if (IsXTurn(board))
            {
                displayOutput.AppendLine($"Player X:");
                var position = MakeMove(board);
                board[position.Item1, position.Item2] = 'X';
            }
            else
            {
                displayOutput.AppendLine($"Player O:");
                var position = MakeMove(board);
                board[position.Item1, position.Item2] = 'O';
            }
           
            BuildBoard(displayOutput,board);
            yield return displayOutput.ToString();
            displayOutput.Clear();
        }
    }

    private static bool CheckDraw(char[,] board)
    {
        var emptySpots = 0;
        for (var y = 0; y < board.GetLength(0); y++)
        {
            for (var x = 0; x < board.GetLength(1); x++)
            {
                if (board[y, x] == ' ')
                {
                    emptySpots++;
                }
            }
        }
        return emptySpots == 0;
    }

    private static (int,int) MakeMove(char[,] board)
    {
        var random = new Random();
        while (true)
        {
            var x = random.Next(0, board.GetLength(0));
            var y = random.Next(0, board.GetLength(0));

            if (board[x, y] == ' ')
            {
                return (x,y);
            }
        }
    }

    private static bool IsXTurn(char[,] board)
    {
        var xCount = 0;
        var oCount = 0;
        for (var y = 0; y < board.GetLength(0); y++)
        {
            for (var x = 0; x < board.GetLength(1); x++)
            {
                if (board[y, x] == 'X')
                {
                    xCount++;
                }

                if (board[y, x] == 'O')
                {
                    oCount++;
                }
            }
        }

        return xCount == oCount;
    }
    
    private static bool CheckDiagonalLines(char[,] board, out char mark)
    {
        if (board[0, 0] != ' ' && board[0,0] == board[1,1] && board[1, 1] == board[2, 2])
        {
            mark = board[0, 0];
            return true;
        }
        if (board[0, 2] != ' ' && board[0,2] == board[1,1] && board[1, 1] == board[2, 0])
        {
            mark = board[0, 2];
            return true;
        }

        mark = ' ';
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
    
    private static bool CheckVerticalLines(char[,] board, out char mark)
    {
        for (var col = 0; col < board.GetLength(0); col++)
        {
            if (board[0,col] != ' ' && board[0, col] == board[1, col] && board[1,col] == board[2, col])
            {
                mark = board[0, col];
                return true;
            }
        }
        mark = ' ';
        return false;
    }

    private static bool CheckHorizontalLines(char[,] board, out char mark)
    {
        for (var row = 0; row < board.GetLength(0); row++)
        {
            if (board[row, 0] != ' ' && board[row,0] == board[row,1] && board[row, 1] == board[row, 2])
            {
                mark = board[row, 0];
                return true;
            }
        }

        mark = ' ';
        return false;
    }
}

