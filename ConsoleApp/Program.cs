// See https://aka.ms/new-console-template for more information

using tic_tac_toe_2;


var board = new char[,]
{
    { ' ', ' ', ' ' },
    { ' ', ' ', ' ' },
    { ' ', ' ', ' ' }
};

foreach (var line in Game.Run(board))
{
    await Task.Delay(2000);
    Console.Clear();
    Console.WriteLine(line);
}