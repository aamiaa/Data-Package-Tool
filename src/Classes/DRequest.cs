using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public bool has_client_mods;
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
                has_client_mods = false,
                browser_user_agent = USER_AGENT,
                browser_version = BROWSER_VERSION_FULL,
                os_version = "10",
                referrer = "",
                referring_domain = "",
                referrer_current = "",
                referring_domain_current = "",
                release_channel = "stable",
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
                {"sec-ch-ua", GetGreasedChromeVersion()},
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

            var res = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://discord.com/app"));
            var content = await res.Content.ReadAsStringAsync();
            foreach (Match match in Regex.Matches(content, @"<script (?:defer )?src=""(\/assets\/.+?\.js)", RegexOptions.None))
            {
                var scriptPath = match.Groups[1].Value;
                var scriptRes = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"https://discord.com{scriptPath}"));
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

        // https://github.com/chromium/chromium/blob/3d78f2a1a74d5fed08f55e0349c21acc7fc2f5fa/components/embedder_support/user_agent_utils.cc#L430
        public static string GetGreasedChromeVersion()
        {
            int seed = int.Parse(BROWSER_VERSION);
            var greasyChars = new string[] { " ", "(", ":", "-", ".", "/", ")", ";", "=", "?", "_" };
            var greasedVersions = new string[] { "8", "99", "24" };

            string greasyBrand =
                "Not" + greasyChars[seed % greasyChars.Length] +
                "A" + greasyChars[(seed + 1) % greasyChars.Length] +
                "Brand";
            string greasyVersion = greasedVersions[seed % greasedVersions.Length];

            var brandVersionList = new List<string[]>{
                new string[] {greasyBrand, greasyVersion},
                new string[] {"Chromium", BROWSER_VERSION},
                new string[] {"Google Chrome", BROWSER_VERSION}
            };

            int[] order;
            int size = brandVersionList.Count;
            switch(size)
            {
                case 2:
                    order = new int[] { seed % size, (seed + 1) % size };
                    break;
                case 3:
                    {
                        var orders = new List<int[]>
                        {
                            new int[] {0, 1, 2}, new int[] {0, 2, 1}, new int[] {1, 0, 2}, new int[] {1, 2, 0}, new int[] {2, 0, 1}, new int[] {2, 1, 0}
                        };
                        order = orders[seed % orders.Count];
                        break;
                    }
                default:
                    {
                        var orders = new List<int[]>
                        {
                            new int[] {0, 1, 2, 3}, new int[] {0, 1, 3, 2}, new int[] {0, 2, 1, 3}, new int[] {0, 2, 3, 1}, new int[] {0, 3, 1, 2},
                            new int[] {0, 3, 2, 1}, new int[] {1, 0, 2, 3}, new int[] {1, 0, 3, 2}, new int[] {1, 2, 0, 3}, new int[] {1, 2, 3, 0},
                            new int[] {1, 3, 0, 2}, new int[] {1, 3, 2, 0}, new int[] {2, 0, 1, 3}, new int[] {2, 0, 3, 1}, new int[] {2, 1, 0, 3},
                            new int[] {2, 1, 3, 0}, new int[] {2, 3, 0, 1}, new int[] {2, 3, 1, 0}, new int[] {3, 0, 1, 2}, new int[] {3, 0, 2, 1},
                            new int[] {3, 1, 0, 2}, new int[] {3, 1, 2, 0}, new int[] {3, 2, 0, 1}, new int[] {3, 2, 1, 0}
                        };
                        order = orders[seed % orders.Count];
                        break;
                    }
            }

            // Initializing this with `brandVersionList` because it's the cleanest way to avoid the index of out bounds error.
            // No, setting Capacity doesn't work for some reason.
            var shuffled = new List<string[]>(brandVersionList);
            for(int i=0;i<order.Length;i++)
            {
                shuffled[order[i]] = brandVersionList[i];
            }

            return String.Join(", ", shuffled.Select(x => $"\"{x[0]}\";v=\"{x[1]}\""));
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
