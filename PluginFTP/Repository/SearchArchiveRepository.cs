using PluginFTP.Models;
using PluginFTP.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PluginFTP.Repository
{
    public class SearchArchiveRepository : ISearchArchiveRepository
    {
        public PluginFtpModel SearchFtp(string url, string username, string password)
        {
            PluginFtpModel pluginFtp = new PluginFtpModel();
            List<FilesModel> filesModel = new List<FilesModel>();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(username, password);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new System.IO.StreamReader(stream))
                    {

                        string line = reader.ReadLine();

                        while (!string.IsNullOrEmpty(line))
                        {
                            FilesModel fileModel = new FilesModel
                            {
                                FileName = Path.GetFileNameWithoutExtension(line),
                                FileExtension = Path.GetExtension(line)
                            };

                            filesModel.Add(fileModel);

                            line = reader.ReadLine();
                        }

                        pluginFtp.Files = filesModel.ToArray();
                        pluginFtp.AmountFiles = filesModel.Count.ToString();
                        pluginFtp.FolderIsEmpty = !string.IsNullOrEmpty(line);
                    }
                }
            }

            return pluginFtp;
        }
    }
}
