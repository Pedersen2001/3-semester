// See https://aka.ms/new-console-template for more information
int randomPlayerNumber;
int oppRandomNumber;

int pointsPlayer = 0;
int pointsAI = 0;

Random random = new Random();

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("  ");

    Console.WriteLine("Press any key to roll the dice. ");

    Console.ReadKey();

    Console.WriteLine("  ");

    randomPlayerNumber = random.Next(1, 7);
    Console.WriteLine("You rolled a dice: " + randomPlayerNumber);

    Console.WriteLine("...");
    System.Threading.Thread.Sleep(1000);

    oppRandomNumber = random.Next(1, 7);
    Console.WriteLine("The AI rolled a dice: " + oppRandomNumber);
    Console.WriteLine("  ");

    if (randomPlayerNumber > oppRandomNumber)
    {
        pointsPlayer++;
        Console.WriteLine("Player (you) wins this round!");
        Console.WriteLine("  ");
    } 
    else if (randomPlayerNumber < oppRandomNumber )
    {
        pointsAI++;
        Console.WriteLine("The AI wins this round!");
        Console.WriteLine("  ");
    }
    else
    {
        Console.WriteLine("You rolled the same dice, and it is therefore a tie!");
        Console.WriteLine();
        Console.WriteLine("  ");
    }

    Console.WriteLine("The score is now - Player : " + pointsPlayer + ". AI : " + pointsAI + ".");
    Console.WriteLine("____________________________________________________________________________");
}

if (pointsPlayer > pointsAI)
{
    Console.WriteLine("Player (you) wins the game!");
    Console.WriteLine("  ");
}
else if (pointsPlayer < pointsAI)
{
    Console.WriteLine("The AI wins the game!");
    Console.WriteLine("  ");
}
else
{
    Console.WriteLine("It is a draw!");
    Console.WriteLine("  ");
}

Console.ReadKey();  