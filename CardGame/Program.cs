// See https://aka.ms/new-console-template for more information
using CardGame;

Console.WriteLine("Welcome to the Card Game!");
Console.WriteLine("Enter a hand of cards (comma-separated), e.g., 2C,3D,JR:");

while (true)
{
    Console.Write("\nEnter hand (or 'exit' to quit): ");
    string input = Console.ReadLine();

    if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
        break;

    try
    {
        int score = CardGameService.CalculateHandScore(input);
        Console.WriteLine($"Hand score: {score}");
    }
    catch (ArgumentException ex)
    {
        // Only print the exception message
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (Exception ex)
    {
        // Catch-all for any other unexpected exceptions
        Console.WriteLine($"Unexpected error: {ex.Message}");
    }
}

Console.WriteLine("Thanks for playing!");