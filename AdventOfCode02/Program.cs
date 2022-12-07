
var allLines = File.ReadAllLines("input.txt");
var totalScore = 0;

foreach (var line in allLines)
{
    var symbols = line.Split(" ");
    var opponentMove = ShapeFromSymbol(symbols[0]);
    var desiredResult = ResultFromSymbol(symbols[1]);
    var myMove = ShapeForResult(opponentMove, desiredResult);

    totalScore += (int)desiredResult + (int)myMove;
}

Console.WriteLine(totalScore);

Shape ShapeFromSymbol(string symbol)
{
    switch (symbol)
    {
        case "A": return Shape.Rock;
        case "B": return Shape.Paper;
        case "C": return Shape.Scissors;
        default: throw new Exception();
    }
}

Shape ShapeForResult(Shape opponentShape, Result desiredResult)
{
    switch (desiredResult)
    {
        case Result.Loss:
            switch (opponentShape)
            {
                case Shape.Rock: return Shape.Scissors;
                case Shape.Paper: return Shape.Rock;
                case Shape.Scissors: return Shape.Paper;
                default: throw new Exception();
            }
        case Result.Draw:
            return opponentShape;
        case Result.Win:
            switch (opponentShape)
            {
                case Shape.Rock: return Shape.Paper;
                case Shape.Paper: return Shape.Scissors;
                case Shape.Scissors: return Shape.Rock;
                default: throw new Exception();
            }
        default:
            throw new Exception();
    }
}

Result ResultFromSymbol(string symbol) {
    switch (symbol)
    {
        case "X": return Result.Loss;
        case "Y": return Result.Draw;
        case "Z": return Result.Win;
        default: throw new Exception(); // this shan't happen
    }
}

enum Shape { Rock = 1, Paper = 2, Scissors = 3 }
enum Result { Loss = 0, Draw = 3, Win = 6 }