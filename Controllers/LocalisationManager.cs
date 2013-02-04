using System;
using System.Collections.Generic;
using System.IO;

namespace DrinkMeter
{
	/// <summary>
	/// this class is here to provide localization texts
	/// </summary>
	public class LocalisationManager
	{
		/// <summary>
		/// The localisations dictionary
		/// </summary>
		protected Dictionary<string,string> localisations;

		/// <summary>
		/// The local folder. -> place where all the localisation files are located
		/// </summary>
		protected string localFolder;

		/// <summary>
		/// Initializes a new instance of the <see cref="DrinkMeter.LocalisationManager"/> class.
		/// </summary>
		/// <param name="localisationFolder">Localisation folder.</param>
		public LocalisationManager (string localisationFolder="")
		{
			if (Directory.Exists(localisationFolder))
				localFolder = localisationFolder;
			else 
				throw new Exception(String.Format("folder {0} does not exists for this application.",localisationFolder));
		}

		/// <summary>
		/// Inits the locale language
		/// </summary>
		/// <param name="locale">Locale.</param>
		public void initLocale (string newLocale)
		{
			//clean or initialise dictionary
			if (localisations == null)
				localisations = new Dictionary<string, string> ();

			lock(localisations)
			{
				localisations.Clear ();

				//-->load and process file 
				string filePath = String.Format ("{0}/loc_{1}.txt", localFolder, newLocale);
				if (File.Exists (filePath)) 
				{
					using (StreamReader strReader = new StreamReader(filePath)) 
					{
						string line;
						while ((line = strReader.ReadLine())!=null) 
						{
							addEntry (line);
						}
					}
				} 
				else 
				{
					throw new Exception (String.Format ("localisation file {0}/loc_{1}.txt does not exists", localFolder, newLocale));
				}
			}
		}

		/// <summary>
		/// add a new entry to the dictionary (= line containing key and value separated by a tab)
		/// </summary>
		/// <param name="value">Value.</param>
		protected void addEntry (string value)
		{

			var tabIndex = value.IndexOf ("\t");
			if (tabIndex == -1) 
				return;
			lock (localisations) 
			{
				localisations.Add (value.Substring (0, tabIndex), value.Substring (tabIndex + 1));
			}
		}

		/// <summary>
		/// Writes all location entries. (only for debug purpose...)
		/// </summary>
		public void writeAllLocEntries ()
		{
			foreach (var element in localisations) 
			{
				Console.WriteLine(element.Key+" -> "+element.Value);

			}
		}

		/// <summary>
		/// Gets the text corresponding to the key
		/// </summary>
		/// <returns>The text.</returns>
		/// <param name="key">Key.</param>
		public string getText (string key)
		{
			lock (localisations) 
			{
				if (localisations == null || localisations.ContainsKey (key))
					return key;

				return localisations [key];
			}
		}

	}
}

