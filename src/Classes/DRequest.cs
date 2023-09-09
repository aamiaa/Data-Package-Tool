using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

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

        public static void Init()
        {
            if (_initialized) return;

            ClientBuildNumber = GetLatestBuildNumber();

            BROWSER_VERSION = GetLatestChromeVersion();
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
                {"Accept-Language", "en-US,en;q=0.5"},
                {"sec-ch-ua", $"\"Not.A/Brand\";v=\"8\", \"Chromium\";v=\"{BROWSER_VERSION}\", \"Google Chrome\";v=\"{BROWSER_VERSION}\""},
                {"sec-ch-ua-mobile", "?0"},
                {"sec-ch-ua-platform", "\"Windows\""},
                {"sec-fetch-dest", "empty"},
                {"sec-fetch-mode", "cors"},
                {"sec-fetch-site", "same-origin"},
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

        public static int GetLatestBuildNumber()
        {
            var web = new WebClient();
            var res = web.DownloadString("https://canary.discord.com/app");
            foreach (Match match in Regex.Matches(res, "<script src=\"(\\/assets\\/[0-9a-f]+\\.js)", RegexOptions.None))
            {
                var scriptPath = match.Groups[1].Value;
                var scriptContent = web.DownloadString($"https://canary.discord.com{scriptPath}");
                if(scriptContent.Contains("build_number"))
                {
                    var buildNumber = Regex.Match(scriptContent, "build_number:\"(\\d+)\"").Groups[1].Value;
                    if(buildNumber != "") return Int32.Parse(buildNumber);
                }
            }

            throw new Exception("Failed to get client build number");
        }

        public static string GetLatestChromeVersion()
        {
            var web = new WebClient();
            var res = web.DownloadString("https://versionhistory.googleapis.com/v1/chrome/platforms/win/channels/stable/versions");
            
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(res);
            string latest = data.versions[0].version;
            var majorNum = latest.Split('.')[0];

            return majorNum;
        }
    }
    class DRequest
    {
        public static DRequestResponse Request(string method, string url, Dictionary<string, string> headers = null, string bodyData = null, bool includeDefaultHeaders = true)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;

            if(headers != null)
            {
                if(headers.ContainsKey("Content-Type"))
                {
                    request.ContentType = headers["Content-Type"];
                    headers.Remove("Content-Type");
                }
            }

            if (includeDefaultHeaders)
            {
                foreach (KeyValuePair<string, string> kvp in DHeaders.DefaultBrowserHeaders(headers))
                {
                    request.Headers.Add(kvp.Key, kvp.Value);
                }
                request.Accept = "*/*";
                request.UserAgent = DHeaders.USER_AGENT;
            } else if(headers != null)
            {
                foreach (KeyValuePair<string, string> kvp in headers)
                {
                    request.Headers.Add(kvp.Key, kvp.Value);
                }
            }

            if(bodyData != null)
            {
                var bytes = Encoding.Default.GetBytes(bodyData);

                request.ContentLength = bytes.Length;
                request.GetRequestStream().Write(bytes, 0, bytes.Length);
            }

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
               
            } catch(WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }

            string body;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                body = reader.ReadToEnd();
            }

            return new DRequestResponse
            {
                response = response,
                body = body
            };
        }
    }

    public class DRequestResponse
    {
        public HttpWebResponse response;
        public string body;
    }
}
