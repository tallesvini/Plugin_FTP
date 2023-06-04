using PluginFTP;
using PluginFTP.Repository.Interfaces;
using PluginFTP.Repository;
using System.Text;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            ISearchArchiveRepository repository = new SearchArchiveRepository();

            IPluginFTP plugin = new PluginFTP.PluginFTP(repository);

            string URL_FTP = "_url_ftp_";
            string USERNAME = "_usuario_";
            string PASSWORD = "_senha_";

            plugin.Initialize(URL_FTP, USERNAME, PASSWORD);

        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }
    }
}