using PluginFTP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginFTP.Repository.Interfaces
{
    public interface ISearchArchiveRepository
    {
        PluginFtpModel SearchFtp(string url, string username, string password);
    }
}
