using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASDAQHistoricalDataDownloader
{
    public class CsvReader
    {
        public List<string> GetAllStockNamesFromCsv(string csvFilePath)
        {
            // Create a new StreamReader object to read the CSV file.
            StreamReader streamReader = new StreamReader(csvFilePath);

            // Read all the lines of the CSV file into a string array.
            List<string> csvLines = new List<string>();
            streamReader.ReadLine(); //Column Names
            while (!streamReader.EndOfStream)
            {
                csvLines.Add(streamReader.ReadLine().Split(',')[0]);
            }

            // Close the StreamReader object.
            streamReader.Close();

            // Return the string array.
            return csvLines;
        }
    }

}
