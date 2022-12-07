var allLines = File.ReadAllLines("input.txt");

var elves = new List<Elf>();
var currentElf = new Elf();

foreach (var line in allLines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        elves.Add(currentElf);
        currentElf = new();
        continue;
    }

    currentElf.FoodItems.Add(int.Parse(line));
}

var topThreeCalories = elves
    .OrderByDescending(e => e.FoodItems.Sum())
    .Take(3)
    .Sum(e => e.FoodItems.Sum());
Console.Write(topThreeCalories);

public record Elf
{
    public List<int> FoodItems = new();
}