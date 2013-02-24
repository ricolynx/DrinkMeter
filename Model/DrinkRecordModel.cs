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
	}
}

