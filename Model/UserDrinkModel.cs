namespace DrinkMeter
{

	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System;

	/// <summary>
	/// Represent the model of a user. It contains all drink records of a user.
	/// </summary>
	public class UserDrinkModel
	{
		public List<DrinkRecordModel> listRecords = new List<DrinkRecordModel>();

		public UserDrinkModel ()
		{
		}
	}
}

