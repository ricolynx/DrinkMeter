namespace DrinkMeter
{
	using System;

	/// <summary>
	/// Controller who manages drinks records of the user.
	/// </summary>
	public class UserDrinkRecordsController
	{
		/// <summary>
		/// The user drink model.
		/// </summary>
		protected UserDrinkModel _userDrinkModel;

		public UserDrinkRecordsController ()
		{
		}

		/// <summary>
		/// Loads the user drink model.
		/// </summary>
		public void loadUserDrinkModel() 
		{

		}

		/// <summary>
		/// Saves the user drink model.
		/// </summary>
		public void saveUserDrinkModel()
		{

		}

		/// <summary>
		/// Adds the new drink record to the user model
		/// </summary>
		/// <param name="date">Date.</param>
		/// <param name="volume">Volume.</param>
		public void addNewDrinkRecord (DateTime date, double volume)
		{
			if (_userDrinkModel == null)
				_userDrinkModel = new UserDrinkModel();


			DrinkRecordModel drink = new DrinkRecordModel ();
			drink.date = date;
			drink.volume = volume;

			_userDrinkModel.listRecords.Add (drink);
		}

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
					result += drink.volume;
				}
			}

			return result;
		}
	}
}

