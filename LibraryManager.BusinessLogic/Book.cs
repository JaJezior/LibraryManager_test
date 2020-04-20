using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManager.BusinessLogic
{
	public class Book
	{
		private readonly List<Rental> history = new List<Rental> ();
		private string author;

		public Book(string Author, string title)
		{
			Author = author;
			Title = title;
		}

		public string Title { get; }

		public string Author { get; }

		public bool IsBookAvailable { get
					{
				return !history.Any() || history.Last().ReturnTime.HasValue;
			}
				}

		public bool TryRent(User user, DateTime time)
		{
			if(IsBookAvailable)
			{
				history.Add(new Rental(user, time));
				return true;
			}
				
			else
			{
				return false;
			}
		}
		public void Return(DateTime time)
		{
			if(IsBookAvailable)
			{
				throw new InvalidOperationException("Book already available");
			}
			history.Last().SetReturn(time);
		}


		private class Rental
		{ public Rental(User user, DateTime rentalTime)
			{
				User = user;
				RentalTime = rentalTime;
			}

			public User User { get; }
			public DateTime RentalTime { get; }

			public DateTime? ReturnTime { get; private set; } // znak zapytania daje możliwość, że pole może być puste

			public void SetReturn (DateTime time)
			{
				if (ReturnTime == null)
					ReturnTime = time;
				else
					throw new InvalidOperationException("Return date alredy set");
			}

		}
	}
}
