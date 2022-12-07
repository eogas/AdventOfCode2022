
var allLines = File.ReadAllLines("input.txt");
var totalScore = 0;

foreach (var line in allLines)
{
    var symbols = line.Split(" ");
    var opponentMove = ShapeFromSymbol(symbols[0]);
    var myMove = ShapeFromSymbol(symbols[1]);

    totalScore += MoveScore(myMove) + (int)OutcomeScore(opponentMove, myMove);
}

Console.WriteLine(totalScore);

Shape ShapeFromSymbol(string symbol) {
    switch (symbol)
    {
        case "A":
        case "X":
            return Shape.Rock;
            
        case "B":
        case "Y":
            return Shape.Paper;
            
        case "C":
        case "Z":
            return Shape.Scissors;
        default:
            throw new Exception();
    }
}

Result OutcomeScore(Shape opponentMove, Shape myMove)
{
    if (opponentMove == myMove) {
        return Result.Draw; //draw
    }

    if (opponentMove == Shape.Rock && myMove == Shape.Scissors ||
        opponentMove == Shape.Paper && myMove == Shape.Rock ||
        opponentMove == Shape.Scissors && myMove == Shape.Paper)
    {
        return Result.Loss; // loss
    }

    if (opponentMove == Shape.Scissors && myMove == Shape.Rock ||
        opponentMove == Shape.Rock && myMove == Shape.Paper ||
        opponentMove == Shape.Paper && myMove == Shape.Scissors)
    {
        return Result.Win; // win
    }

    return Result.Draw; // this shan't happen
}

int MoveScore(Shape move) => (int)move;

enum Shape { Rock = 1, Paper = 2, Scissors = 3 }
enum Result { Loss = 0, Draw = 3, Win = 6 }
