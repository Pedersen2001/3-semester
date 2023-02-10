using F_Klub_Stregsystem.Classes;
using F_Klub_Stregsystem.FileReader;
using F_Klub_Stregsystem.Interfaces;
using System.Text.RegularExpressions;

namespace F_Klub_Stregsystem
{
    class Program
    {
        static void Main(string[] args)
        {
			ReadUsersFile userParser = new ReadUsersFile();
			ReadProductsFile productParser = new ReadProductsFile();
			IIdProvider idProvider = new IdProvider();

			IStregsystem stregsystem = new Stregsystem(
				productParser.Parse(File.ReadLines(@"C:\Users\lucas\GitRepos\3-semester\F-Klub Stregsystem\F-Klub Stregsystem\files\products.csv").Skip(1), idProvider),
				userParser.Parse(File.ReadLines(@"C:\Users\lucas\GitRepos\3-semester\F-Klub Stregsystem\F-Klub Stregsystem\files\users.csv").Skip(1), idProvider),
				idProvider
			);

			IStregsystemUI ui = new StregsystemUI(stregsystem);
			StregsystemCommandParser commandParser = new StregsystemCommandParser(stregsystem, ui);

			ui.Start();
		}
    }
}
