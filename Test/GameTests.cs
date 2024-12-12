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

        result.First().Should().Be("Game Board Creation...\r\n | | \r\n-+-+-\r\n | | \r\n-+-+-\r\n | | \r\n\r\nBoard Created.\r\nThe game will start with player X\r\n");
    }

    [Fact]
    public void Game_HorizontalLineAllX_ShouldReturnXWinner()
    {
        var board = new char[,]
        {
            { 'X', ' ', ' ' },
            { 'X', ' ', ' ' },
            { 'X', ' ', ' ' }
        };
        
        var result = Game.Run(board);

        result.First().Should().Be("Player X:\r\nX| | \r\n-+-+-\r\nX|O| \r\n-+-+-\r\nX| |O\r\n\r\nPlayer X Won\r\n");
    }
}
