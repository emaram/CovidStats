using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CovidStatsAPI
{
    public class CovidInfo
    {
        private void DownloadCovidInfoFile(string url, string filename)
		{
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

    		StreamReader sr = new StreamReader(resp.GetResponseStream());
    		string results = sr.ReadToEnd();
    		sr.Close();

			StreamWriter sw = new StreamWriter(filename, false);
			sw.WriteLine(results);
			sw.Close();
		}

		public IEnumerable<string[]> GetInfo(string country) 
		{
			//this.DownloadCovidInfoFile("https://opendata.ecdc.europa.eu/covid19/casedistribution/csv", "covid.csv");

			// No need to download the covid.csv file. Just take the HttpWebResponse as a response stream
			
			string url = "https://opendata.ecdc.europa.eu/covid19/casedistribution/csv";
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

			List<string[]> result = new List<string[]>();
			using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
			{
				// Add header row
				result.Add(sr.ReadLine().Split(','));

				// Now add the other rows
				while (!sr.EndOfStream)
				{
					string[] row = sr.ReadLine().Split(',');
					if (row.Length > 8)
					{
						if (country.Trim().Length == 0)
							result.Add(row);
						else
						{
							if (country.ToUpper() == row[8].ToUpper())
								result.Add(row);
						}
					}
				}
			}

			return result;
		}
    }
}
