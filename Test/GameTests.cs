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

    [Theory]
    [InlineData(0,'X', "Player X:\r\nX| | \r\n-+-+-\r\nX| | \r\n-+-+-\r\nX| | \r\n\r\nPLAYER X WON!")]
    [InlineData(1,'X', "Player X:\r\n |X| \r\n-+-+-\r\n |X| \r\n-+-+-\r\n |X| \r\n\r\nPLAYER X WON!")]
    [InlineData(2,'X', "Player X:\r\n | |X\r\n-+-+-\r\n | |X\r\n-+-+-\r\n | |X\r\n\r\nPLAYER X WON!")]
    [InlineData(0,'O', "Player O:\r\nO| | \r\n-+-+-\r\nO| | \r\n-+-+-\r\nO| | \r\n\r\nPLAYER O WON!")]
    [InlineData(1,'O', "Player O:\r\n |O| \r\n-+-+-\r\n |O| \r\n-+-+-\r\n |O| \r\n\r\nPLAYER O WON!")]
    [InlineData(2,'O', "Player O:\r\n | |O\r\n-+-+-\r\n | |O\r\n-+-+-\r\n | |O\r\n\r\nPLAYER O WON!")]
    public void Game_VerticalLineAllX_ShouldReturnXWinner(int col, char mark, string expected)
    {
        var board = col switch
        {
            0 => new char[,]
            {
                { mark, ' ', ' ' },
                { mark, ' ', ' ' },
                { mark, ' ', ' ' }
            },
            1 => new char[,]
            {
                { ' ', mark, ' ' },
                { ' ', mark, ' ' },
                { ' ', mark, ' ' }
            },
            2 => new char[,]
            {
                { ' ', ' ', mark },
                { ' ', ' ', mark },
                { ' ', ' ', mark }
            },
        };
        
        var result = Game.Run(board);

        result.Should().Contain(expected);
    }

    [Theory]
    [InlineData(0,'O' ,"Player O:\r\nO|O|O\r\n-+-+-\r\n | | \r\n-+-+-\r\n | | \r\n\r\nPLAYER O WON!")]
    [InlineData(1,'O' ,"Player O:\r\n | | \r\n-+-+-\r\nO|O|O\r\n-+-+-\r\n | | \r\n\r\nPLAYER O WON!")]
    [InlineData(2,'O' ,"Player O:\r\n | | \r\n-+-+-\r\n | | \r\n-+-+-\r\nO|O|O\r\n\r\nPLAYER O WON!")]
    [InlineData(0,'X' ,"Player X:\r\nX|X|X\r\n-+-+-\r\n | | \r\n-+-+-\r\n | | \r\n\r\nPLAYER X WON!")]
    [InlineData(1,'X' ,"Player X:\r\n | | \r\n-+-+-\r\nX|X|X\r\n-+-+-\r\n | | \r\n\r\nPLAYER X WON!")]
    [InlineData(2,'X' ,"Player X:\r\n | | \r\n-+-+-\r\n | | \r\n-+-+-\r\nX|X|X\r\n\r\nPLAYER X WON!")]
    public void Game_HorizontalLineAllO_ShouldReturnOWinner(int row, char mark, string expected)
    {
        
        var board = row switch
        {
            0 => new char[,]
            {
                { mark, mark, mark },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            },
            1 => new char[,]
            {
                { ' ', ' ', ' ' },
                { mark, mark, mark },
                { ' ', ' ', ' ' }
            },
            2 => new char[,]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { mark, mark, mark }
            },
        };
        
        
        var result = Game.Run(board);

        result.Should().Contain(expected);
    }

    [Theory]
    [InlineData(1,'O' ,"Player O:\r\nO| | \r\n-+-+-\r\n |O| \r\n-+-+-\r\n | |O\r\n\r\nPLAYER O WON!")]
    [InlineData(2,'O' ,"Player O:\r\n | |O\r\n-+-+-\r\n |O| \r\n-+-+-\r\nO| | \r\n\r\nPLAYER O WON!")]
    [InlineData(1,'X' ,"Player X:\r\nX| | \r\n-+-+-\r\n |X| \r\n-+-+-\r\n | |X\r\n\r\nPLAYER X WON!")]
    [InlineData(2,'X' ,"Player X:\r\n | |X\r\n-+-+-\r\n |X| \r\n-+-+-\r\nX| | \r\n\r\nPLAYER X WON!")]
    public void Game_DiagonalLineAllO_ShouldReturnOWinner(int position, char mark, string expected)
    {
        var board = position switch
        {
            1 => new char[,]
            {
                { mark, ' ', ' ' },
                { ' ', mark, ' ' },
                { ' ', ' ', mark }
            },
            2 => new char[,]
            {
                { ' ', ' ', mark },
                { ' ', mark, ' ' },
                { mark, ' ', ' ' }
            }
        };
        
        var result = Game.Run(board);
        result.Should().Contain(expected);
    }

    [Fact]
    public void Game_PlayerOMakeRandomMove_ShouldReturnBoardWithRandomMove()
    {
        var board = new char[,]
        {
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' },
            { ' ', ' ', ' ' }
        };

        var result = Game.Run(board).ToList();

        result[1].Count(p => p.Equals('X')).Should().Be(2);
    }

    [Fact]
    public void Game_NoMoreMoveToMakeAndNoThreeMarksInARow_ShouldReturnDraw()
    {
        var board = new char[,]
        {
            { 'X', 'O', 'X' },
            { 'X', 'O', 'O' },
            { 'O', 'X', 'X' }
        };

        var result = Game.Run(board).ToList();

        result.Should().Contain("Player O:\r\nX|O|X\r\n-+-+-\r\nX|O|O\r\n-+-+-\r\nO|X|X\r\n\r\nTHE GAME ENDS WITH A DRAW!");
    }
}
