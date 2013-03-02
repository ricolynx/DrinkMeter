using System.IO;

namespace DrinkMeter
{
	using System;

	/// <summary>
	/// Controller who manages drinks records of the user.
	/// </summary>
	public class UserDrinkRecordsController
	{

		#region data file path
		private string _saveFile = "";

		/// <summary>
		/// The save file path
		/// </summary>
		public string saveFile 
		{
			get
			{
				if (_saveFile == "")
				{
					var documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
					var library = Path.Combine (documents, "..", "Library");
					_saveFile = Path.Combine (library, "data.txt");
				}
				return _saveFile;
			}
		}

		#endregion


		#region properties
		/// <summary>
		/// The user drink model.
		/// </summary>
		protected UserDrinkModel _userDrinkModel;

		#endregion


		public UserDrinkRecordsController ()
		{
		}

		#region load
		/// <summary>
		/// Loads the user drink model.
		/// </summary>
		public void loadUserDrinkModel() 
		{
			//-->check if the file exists if not create it
			if (!File.Exists(saveFile))
			{
				File.Create(saveFile);
			}

			//--> clean the currentDrinkModel
			_userDrinkModel = new UserDrinkModel();

			//-->read the file and parse it in the _userDrinkModel
			using (TextReader reader = File.OpenText (saveFile))
			{
				while (reader.Peek() > -1)
				{
					//add a new drink in the drinks model
					parseLine(reader.ReadLine());
				}
			}
		}

		/// <summary>
		/// Parses a line of the database and add the data to the drink model
		/// </summary>
		/// <param name="line">Line.</param>
		protected void parseLine(string line)
		{
			if (string.IsNullOrEmpty (line))
				return;

			var parsedLine = line.Split ('\t');
			
			if (parsedLine.Length != DrinkRecordModel.length)
				return;

			DrinkRecordModel drink = new DrinkRecordModel (parsedLine [0], parsedLine [1]);
			_userDrinkModel.listRecords.Add (drink);
		}

		#endregion


		#region save

		/// <summary>
		/// Resets all user data.
		/// </summary>
		public void resetAllData() 
		{
			if (File.Exists (saveFile))
				File.Delete (saveFile);
		}

		/// <summary>
		/// Saves the entire user drink model.
		/// </summary>
		public void saveUserDrinkModel()
		{
			if (_userDrinkModel == null)
				return;

			if (File.Exists (saveFile))
				File.Delete (saveFile);

			File.Create (saveFile);

			using (TextWriter writer = new StreamWriter (saveFile))
			{
				foreach(var drink in _userDrinkModel.listRecords)
				{
					writer.WriteLine(drink.ToString());
				}
			}
		}



		/// <summary>
		/// Saves the new drink in the file
		/// </summary>
		/// <param name="drink">Drink.</param>
		protected void saveNewDrink(DrinkRecordModel drink)
		{
			if (!File.Exists (saveFile))
				File.Create (saveFile);

			using (TextWriter writer = File.AppendText(saveFile))
			{
				writer.WriteLine(drink.ToString());
			}
		}

		#endregion


		#region creation of new drinks

		/// <summary>
		/// Adds the new drink record to the user model
		/// </summary>
		/// <param name="date">Date.</param>
		/// <param name="volume">Volume.</param>
		public void addNewDrinkRecord (DateTime date, double volume)
		{
			DrinkRecordModel drink = new DrinkRecordModel ();
			drink.date = date;
			drink.volume = volume;

			addNewDrinkRecord (drink);
		}

		/// <summary>
		/// Adds the new drink record to the user model
		/// </summary>
		/// <param name="drink">Drink.</param>
		public void addNewDrinkRecord(DrinkRecordModel drink)
		{
			if (drink == null)
				return;

			if (_userDrinkModel == null)
				_userDrinkModel = new UserDrinkModel();

			_userDrinkModel.listRecords.Add (drink);
			saveNewDrink (drink);
		}

		#endregion


		#region div
		/// <summary>
		/// Gets the total user drink volume 
		/// </summary>
		/// <returns>The total user drink volume.</returns>
		public double getTotalUserDrinkVolume()
		{
			double result = 0;

			if (_userDrinkModel != null && _userDrinkModel.listRecords !=null) 
			{
				foreach (DrinkRecordModel drink in _userDrinkModel.listRecords) 
				{
					Console.WriteLine(drink.ToString());
					result += drink.volume;
				}
			}

			return result;
		}

		#endregion
	}
}

