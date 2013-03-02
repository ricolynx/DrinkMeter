namespace DrinkMeter
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Represent a drink record
	/// </summary>
	public class DrinkRecordModel
	{
		/// <summary>
		/// number of properties in the DrinkRecordModel (this is used for the backup of the data)
		/// </summary>
		public const int length = 2;

		/// <summary>
		/// date of the record
		/// </summary>
		public DateTime date;

		/// <summary>
		/// volume of the record
		/// </summary>
		public double volume;

		public DrinkRecordModel ()
		{
		}

		public DrinkRecordModel(string d, string v)
		{
			date = DateTime.Parse (d);
			volume = double.Parse (v);
		}

		public string ToString()
		{
			return string.Format ("{0}\t{1}", date.ToString() , volume.ToString());
		}
	}
}

