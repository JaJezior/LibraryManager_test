using System;
using System.Linq;
using LibraryManager.BusinessLogic;

namespace LibraryManager
{
	public class Program
	{

		private static Library library = new Library();
		
		
		static void Main()
		{ 
		//		static int GetDamerauLevenshteinDistance(string s, string t) komentarz dla commita tekst
		//{

		//	s = s.ToLowerInvariant();
		//	t = t.ToLowerInvariant();
		//	var bounds = new { Height = s.Length + 1, Width = t.Length + 1 }; int[,] matrix = new int[bounds.Height, bounds.Width]; for (int height = 0; height < bounds.Height; height++) { matrix[height, 0] = height; };
		//	for (int width = 0; width < bounds.Width; width++) { matrix[0, width] = width; }; for (int height = 1; height < bounds.Height; height++)
		//	{
		//		for (int width = 1; width < bounds.Width; width++)
		//		{
		//			int cost = (s[height - 1] == t[width - 1]) ? 0 : 1;
		//			int insertion = matrix[height, width - 1] + 1;
		//			int deletion = matrix[height - 1, width] + 1;
		//			int substitution = matrix[height - 1, width - 1] + cost; int distance = Math.Min(insertion, Math.Min(deletion, substitution)); if (height > 1 && width > 1 && s[height - 1] == t[width - 2] && s[height - 2] == t[width - 1])
		//			{
		//				distance = Math.Min(distance, matrix[height - 2, width - 2] + cost);
		//			}
		//			matrix[height, width] = distance;
		//		}
		//	}
		//	return matrix[bounds.Height - 1, bounds.Width - 1];
		//} to jest metoda, która pozwala literówki

		
			int input;
			do { 
			PrintMenu();
			
			input = int.Parse(Console.ReadLine());


				switch (input)
				{
					case 1:
						{ 
						string author = AskUser("Podaj autora");
						string title = AskUser("Podaj książkę");

						var book = new Book(author, title);
						library.Books.Add(book);
						break;
						}
					case 2:
						{
							string name = AskUser("Podaj nazwę użytkownika");

							var user = new User(name);
							library.Users.Add(user);
							break;
						}
					case 3:
						{
							string author = AskUser("Podaj autora");
							string title = AskUser("Podaj książkę");
							var bookId = library.Books.FindIndex(b => b.IsBookAvailable && b.Title == title && b.Author == author);
						
							
							if(bookId == -1)
							{
								Console.WriteLine("Brak książki");
								break;
							}

							var username = AskUser("Podaj nazwę użytkownika");
							var user = library.Users.FirstOrDefault(u => u.Name == username);

							if (user == null)
							{
								Console.WriteLine("Brak użytkownika");
								break;
							}
							if(library.Books[bookId].TryRent(user, DateTime.Now))

								Console.WriteLine($"Wypożyczona książka numer (index) {bookId}");
							else
									Console.WriteLine("Błąd!");
							break;
						}
					case 4:
						{
							var bookId = int.Parse(AskUser("Podaj numer (index) książki"));
							library.Books[bookId].Return(DateTime.Now);
							Console.WriteLine("Zwrot zakończony pomyślnie");
						}
						break;
					case 5:
						{

						}
							break;
				}
			}
			while ( input !=0 );
			}

		private static string AskUser(string question)
		{
			Console.Write($"{question}:  ");
			return  Console.ReadLine();
			
		}

		private static void PrintMenu()
		{
			Console.WriteLine("1 - Dodaj Książkę");
			Console.WriteLine("2 - Dodaj Użytkownika");
			Console.WriteLine("3 - Wypożycz książkę");
			Console.WriteLine("4 - Oddaj książkę");
			Console.WriteLine("5 - Wyślwietl historię wypożyczeń książki");
			Console.WriteLine("6 - Wyślwietl stan wypożyczeń użytkownika");
			Console.WriteLine("0 - Zakończ");
		}
	}
}