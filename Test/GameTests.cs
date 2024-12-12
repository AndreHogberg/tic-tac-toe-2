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

        result.First().Should().Be(" | | " +
                                   "-+-+-" +
                                   " | | " +
                                   "-+-+-" +
                                   " | | ");
    }
}
