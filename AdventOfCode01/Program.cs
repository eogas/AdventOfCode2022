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

var maxCalories = elves.Max(e => e.FoodItems.Sum());
Console.Write(maxCalories);

public record Elf
{
    public List<int> FoodItems = new();
}