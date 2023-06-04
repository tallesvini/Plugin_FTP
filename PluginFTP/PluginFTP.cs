using PluginFTP.Models;
using PluginFTP.Repository.Interfaces;

namespace PluginFTP
{
    public class PluginFTP : IPluginFTP
    {
        private readonly ISearchArchiveRepository _archiveRepository;

        public PluginFTP(ISearchArchiveRepository archiveRepository)
        {
            _archiveRepository = archiveRepository;
        }

        public void Initialize(string url, string user, string pass)
        {
            Execute(url, user, pass);
        }

        public PluginFtpModel Execute(string url, string user, string pass)
        {
            var content = _archiveRepository.SearchFtp(url, user, pass);

            return content;
        }
    }
}
