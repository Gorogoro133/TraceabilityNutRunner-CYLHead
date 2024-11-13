using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FluentFTP;

namespace TraceabilityNutRunner_CYLHead
{
    public class FtpService
    {
        private readonly FtpClient _ftpClient;
        public bool IsFtpConnected { get; private set; } = false;

        public FtpService(string host, string username, string password)
        {
            _ftpClient = new FtpClient(host, username, password);
        }

        public bool Login()
        {
            try
            {
                _ftpClient.Connect();
                IsFtpConnected = _ftpClient.IsConnected;
                Console.WriteLine(IsFtpConnected ? "FTP connection established successfully." : "Failed to connect to FTP.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to FTP: {ex.Message}");
                IsFtpConnected = false;
            }

            return IsFtpConnected;
        }

        public bool IsConnected()
        {
            // Corrected: checking the connection status of _ftpClient
            return _ftpClient.IsConnected;
        }

        public List<DataFromCsv> GetAllDataFromCSV(string filePath)
        {
            var dataList = new List<DataFromCsv>();

            try
            {
                if (IsFtpConnected && _ftpClient.FileExists(filePath))
                {
                    using (var stream = new MemoryStream())
                    {
                        _ftpClient.DownloadStream(stream, filePath);
                        stream.Position = 0;

                        using (var reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                var columns = line.Split(',');
                                var data = new DataFromCsv
                                {
                                    Datatime = columns.Length > 0 ? columns[0] : string.Empty,
                                    DataArray = new string[60],
                                    Engine_No = columns.Length > 61 ? columns[61] : string.Empty
                                };

                                for (int i = 0; i < 60; i++)
                                {
                                    data.DataArray[i] = columns.Length > 1 + i ? columns[1 + i] : string.Empty;
                                }

                                dataList.Add(data);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File not found on FTP server or not connected.");
                    IsFtpConnected = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing FTP data: {ex.Message}");
                IsFtpConnected = false;
            }

            return dataList;
        }

        public void Logout()
        {
            try
            {
                if (_ftpClient.IsConnected)
                {
                    _ftpClient.Disconnect();
                    Console.WriteLine("Disconnected from FTP server.");
                }
                IsFtpConnected = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error disconnecting from FTP: {ex.Message}");
            }
        }
    }
}
