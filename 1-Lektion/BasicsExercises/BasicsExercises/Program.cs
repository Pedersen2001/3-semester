// See https://aka.ms/new-console-template for more information
// BasicsExercise 1:
/*
char a = "a";
bool b = 0;
int c = 8.0;
decimal d = 6.7;
string e = "Har du set "Holger"?";
*/


//BasicsExercise 2:
    string input;
    int grader;
    int radian;

    System.Console.WriteLine("Konverter fra grader til radian eller omvendt?");
    System.Console.WriteLine("Skriv 'Radian' for at konverter TIL radian. Skriv 'Grader' for at konverter TIL grader");

    input = System.Console.ReadLine();

    if (input == "Radian")
    {
        System.Console.WriteLine("Hvor mange grader vil du konvertere?");

        grader = Convert.ToInt32(System.Console.ReadLine());

        System.Console.WriteLine("Dine grader svarer til: " + (grader * (3.14/180)) + " radianer");

    } else if (input == "Grader")
    {
    System.Console.WriteLine("Hvor mange radianer vil du konvertere?");

    radian = Convert.ToInt32(System.Console.ReadLine());

    System.Console.WriteLine("Dine radianer svarer til: " + (radian * (180 / 3.14)) + " grader");
    }

