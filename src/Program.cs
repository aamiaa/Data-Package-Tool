using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

[assembly: DisableDpiAwareness]
namespace Data_Package_Tool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        public static async Task<bool> CheckForUpdates()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");
            string version = await client.GetStringAsync("https://raw.githubusercontent.com/aamiaa/Data-Package-Tool/main/version.txt");
            if(version != Application.ProductVersion)
            {
                return true;
            }

            return false;
        }
    }
}
