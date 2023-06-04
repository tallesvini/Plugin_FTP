using PluginFTP.Models;

namespace PluginFTP
{
    public interface IPluginFTP
    {
        void Initialize(string url, string user, string pass);
        PluginFtpModel Execute(string url, string user, string pass);
    }
}