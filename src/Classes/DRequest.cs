using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data_Package_Tool.Classes
{
    class DSuperProperties
    {
        public string os;
        public string browser;
        public string device;
        public string system_locale;
        public string browser_user_agent;
        public string browser_version;
        public string os_version;
        public string referrer;
        public string referring_domain;
        public string referrer_current;
        public string referring_domain_current;
        public string release_channel;
        public int client_build_number;
        public string client_event_source;

    }
    class DHeaders
    {
        public static string BROWSER_VERSION;
        public static string BROWSER_VERSION_FULL;

        public static string USER_AGENT;

        public static int ClientBuildNumber;

        private static bool _initialized = false;

        public static async Task Init()
        {
            if (_initialized) return;

            ClientBuildNumber = await GetLatestBuildNumber();

            BROWSER_VERSION = await GetLatestChromeVersion();
            BROWSER_VERSION_FULL = $"{ BROWSER_VERSION}.0.0.0";
            USER_AGENT = $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/{BROWSER_VERSION_FULL} Safari/537.36";

            _initialized = true;
        }

        public static string SuperProperties()
        {
            if (!_initialized) throw new Exception("Headers not initialized");

            var propsJson = Newtonsoft.Json.JsonConvert.SerializeObject(new DSuperProperties
            {
                os = "Windows",
                browser = "Chrome",
                device = "",
                system_locale = "en-US",
                browser_user_agent = USER_AGENT,
                browser_version = BROWSER_VERSION_FULL,
                os_version = "10",
                referrer = "",
                referring_domain = "",
                referrer_current = "",
                referring_domain_current = "",
                release_channel = "canary",
                client_build_number = ClientBuildNumber,
                client_event_source = null
            });

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(propsJson));
        }

        public static Dictionary<string, string> DefaultBrowserHeaders(Dictionary<string, string> extraHeaders = null)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>{
                {"Accept", "*/*"},
                {"Accept-Language", "en-US,en;q=0.5"},
                {"sec-ch-ua", $"\"Not.A/Brand\";v=\"8\", \"Chromium\";v=\"{BROWSER_VERSION}\", \"Google Chrome\";v=\"{BROWSER_VERSION}\""},
                {"sec-ch-ua-mobile", "?0"},
                {"sec-ch-ua-platform", "\"Windows\""},
                {"sec-fetch-dest", "empty"},
                {"sec-fetch-mode", "cors"},
                {"sec-fetch-site", "same-origin"},
                {"User-Agent", USER_AGENT},
                {"x-debug-options", "bugReporterEnabled"},
                {"x-discord-locale", "en-US"},
                {"x-discord-timezone", "America/New_York"},
                {"x-super-properties", SuperProperties()}
            };

            if(extraHeaders != null)
            {
                foreach(KeyValuePair<string, string> kvp in extraHeaders)
                {
                    headers.Add(kvp.Key, kvp.Value);
                }
            }

            return headers;
        }

        public static async Task<int> GetLatestBuildNumber()
        {
            var client = new HttpClient();

            var res = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://canary.discord.com/app"));
            var content = await res.Content.ReadAsStringAsync();
            foreach (Match match in Regex.Matches(content, "<script src=\"(\\/assets\\/.+?\\.js)", RegexOptions.None))
            {
                var scriptPath = match.Groups[1].Value;
                var scriptRes = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"https://canary.discord.com{scriptPath}"));
                var scriptContent = await scriptRes.Content.ReadAsStringAsync();
                if(scriptContent.Contains("build_number"))
                {
                    var buildNumber = Regex.Match(scriptContent, "build_number:\"(\\d+)\"").Groups[1].Value;
                    if(buildNumber != "") return Int32.Parse(buildNumber);
                }
            }

            throw new Exception("Failed to get client build number");
        }

        public static async Task<string> GetLatestChromeVersion()
        {
            var res = await new HttpClient().SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://versionhistory.googleapis.com/v1/chrome/platforms/win/channels/stable/versions"));
            var content = await res.Content.ReadAsStringAsync();
            
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(content);
            string latest = data.versions[0].version;
            var majorNum = latest.Split('.')[0];

            return majorNum;
        }
    }
    class DRequest
    {
        public static HttpClient client = new HttpClient();
        public static async Task<DRequestResponse> RequestAsync(HttpMethod method, string url, Dictionary<string, string> headers = null, string bodyData = null, bool includeDefaultHeaders = true)
        {
            var request = new HttpRequestMessage(method, url);

            if (includeDefaultHeaders)
            {
                foreach (KeyValuePair<string, string> kvp in DHeaders.DefaultBrowserHeaders(headers))
                {
                    request.Headers.Add(kvp.Key, kvp.Value);
                }
            } else if(headers != null)
            {
                foreach (KeyValuePair<string, string> kvp in headers)
                {
                    request.Headers.Add(kvp.Key, kvp.Value);
                }
            }

            if(bodyData != null)
            {
                request.Content = new StringContent(bodyData, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response;
            response = await client.SendAsync(request);

            return new DRequestResponse
            {
                response = response,
                body = await response.Content.ReadAsStringAsync()
            };
        }
    }

    public class DRequestResponse
    {
        public HttpResponseMessage response;
        public string body;
    }
}
