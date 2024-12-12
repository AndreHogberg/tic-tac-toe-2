using FluentAssertions;
using tic_tac_toe_2;

namespace Test;

public class GameTests
{
    [Fact]
    public void Game_EmptyBoard_ShouldReturnDisplayOfBoard()
    {
        var board = new char[,]
        {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };
        
        var result = Game.Run(board);

        result.First().Should().Be("Game Board Creation...\r\n | | \r\n-+-+-\r\n | | \r\n-+-+-\r\n | | \r\n\r\nBoard Created.\r\nThe game will start with player X");
    }

    [Fact]
    public void Game_VerticalLineAllX_ShouldReturnXWinner()
    {
        var board = new char[,]
        {
            { 'X', ' ', ' ' },
            { 'X', ' ', ' ' },
            { 'X', ' ', ' ' }
        };
        
        var result = Game.Run(board);

        result.First().Should().Be("Player X:\r\nX| | \r\n-+-+-\r\nX|O| \r\n-+-+-\r\nX| |O\r\n\r\nPLAYER X WON!");
    }

    [Fact]
    public void Game_HorizontalLineAllO_ShouldReturnOWinner()
    {
        var board = new char[,]
        {
            { 'X', ' ', 'X' },
            { 'O', 'O', 'O' },
            { 'X', ' ', ' ' }
        };
        
        var result = Game.Run(board);

        result.First().Should().Be("Player O:\r\nX| |X\r\n-+-+-\r\nO|O|O\r\n-+-+-\r\nX| | \r\n\r\nPLAYER O WON!");
    }
}
