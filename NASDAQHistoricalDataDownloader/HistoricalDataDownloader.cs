using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NASDAQHistoricalDataDownloader
{
    public class NasdaqHistoricalDataDownloader
    {
        public void DownloadHistoricalData(string stockTicker)
        {
            string downloadDirectory = @"..\HistoricalData"; // Specify the download directory

            ChromeOptions chromeOptions = new ChromeOptions();

            // Set the download directory and disable prompting for downloads
            chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            // Set up the Chrome WebDriver
            IWebDriver driver = new ChromeDriver(chromeOptions);

            try
            {
                var url = $"https://www.nasdaq.com/market-activity/stocks/{stockTicker.ToLowerInvariant()}/historical";
                // Navigate to the URL of the document you want to download
                driver.Navigate().GoToUrl(url);

                IWebElement maxButton = driver.FindElement(By.CssSelector(".table-tabs__tab[data-value=\"y10\"]"));

                maxButton.Click();

                // Locate the download button using a CSS selector (change to your preferred selector)
                IWebElement downloadButton = driver.FindElement(By.CssSelector(".historical-download")); // Replace with the actual selector

                // Click the download button
                downloadButton.Click();

                Task.Delay(10000).Wait();

                // Rename the downloaded file based on the stockTicker
                string newFilePath = Path.Combine(downloadDirectory, $"{stockTicker}.csv");


                // Get all the files in the current directory and its subdirectories.
                string[] files = Directory.GetFiles(downloadDirectory, "*", SearchOption.AllDirectories);

                // Filter the files to find the ones that contain "HistoricalData" in their path.
                string[] historicalDataFiles = files.Where(f => f.Contains("HistoricalData_")).ToArray();


                if(historicalDataFiles.Length > 0)
                {
                    File.Move(historicalDataFiles[0], newFilePath);
                }


            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Close the browser
                driver.Quit();
            }
        }
    }
}
