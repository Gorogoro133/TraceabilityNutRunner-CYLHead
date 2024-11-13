using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace TraceabilityNutRunner_CYLHead
{
    public class CsvReaderService
    {
        const string okFtpUrl = "ftp://192.168.137.82/LOGGING_00_00_OK.csv";
        const string nokFtpUrl = "ftp://192.168.137.82/LOGGING_00_01_NOK.csv";
        const string ftpUsername = "Intouch";
        const string ftpPassword = "1111";
        //const string okFtpUrl = "ftp://172.16.2.3/GIKENGSS/LOGGING/LOGGING_00_00_OK.CSV";
        //const string nokFtpUrl = "ftp://172.16.2.3/GIKENGSS/LOGGING/LOGGING_00_01_NOK.CSV";
        //const string ftpUsername = "maintenance";
        //const string ftpPassword = "12345678";



        public async Task<List<DataCsvReader>> ReadCsvData(string status)
        {
            var ftpUrl = status == "OK" ? okFtpUrl : nokFtpUrl;
            var dataList = new List<DataCsvReader>();

            try
            {
                var allData = await GetAllDataFromCSV(ftpUrl, ftpUsername, ftpPassword);
                dataList.AddRange(allData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV: {ex.Message}");
            }

            return dataList;
        }

        private async Task<List<DataCsvReader>> GetAllDataFromCSV(string ftpUrl, string username, string password)
        {
            var dataList = new List<DataCsvReader>();
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(username, password);

                using (var response = (FtpWebResponse)await request.GetResponseAsync())
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            string csvContent = await reader.ReadToEndAsync();
                            string[] lines = csvContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (var line in lines)
                            {
                                var columns = line.Split(',');

                                var data = new DataCsvReader
                                {
                                    Datatime = columns.Length > 0 ? columns[0] : string.Empty,
                                    Engine_No = columns.Length > 1 ? columns[1] : string.Empty,
                                    DataArray = new string[60]
                                };

                                for (int i = 0; i < 60; i++)
                                {
                                    if (columns.Length > 2 + i)
                                    {
                                        data.DataArray[i] = columns[2 + i];
                                    }
                                    else
                                    {
                                        data.DataArray[i] = string.Empty;
                                    }
                                }

                                dataList.Add(data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file from FTP: {ex.Message}");
            }

            return dataList;
        }

        

    }



    public class DataCsvReader
    {
        public string Datatime { get; set; }
        public string Engine_No { get; set; }
        public string[] DataArray { get; set; }
    }
}
