namespace tic_tac_toe_2;

public class Game
{
    public static IEnumerable<string> Run(char[,] board)
    {
        yield return " | | " +
               "-+-+-" +
               " | | " +
               "-+-+-" +
               " | | ";
    }
}
