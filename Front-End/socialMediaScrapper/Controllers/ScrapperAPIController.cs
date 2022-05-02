using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;

namespace socialMediaScrapper.Controllers
{
    [RoutePrefix("api/ScrapperAPI")]
    public class ScrapperAPIController : ApiController
    {
        public List<string> Get()
        {
            return new List<string> {
                "List of API Endpoints:",
                "GetDataFromTwitter/{UserName}",
                "GetDataFromFacebook/{UserName}",
                "GetDataFromGithub/{UserName}",
                "GetDataFromInstagram/{UserName}",
                "GetDataFromPinterest/{UserName}",
                "GetDataFromQuora/{UserName}",
                "GetDataFromReddit/{UserName}",
                "GetDataFromTikTok/{UserName}",
            };
        }

        [Route("GetDataFromTwitter/{UserName}")]
        [HttpGet]
        public Task<JObject> GetDataFromTwitter(string UserName)
        {
            string appPath = "https://social-back.azurewebsites.net/twitter/" + UserName;

            //#if DEBUG
            //    appPath = Path.Combine(@"C:\", @"ScrapperScripts\twitter.py "+ UserName + " --browser chrome");
            //#endif

            return pythonRunner(appPath);
        }

        [Route("GetDataFromFacebook/{UserName}")]
        [HttpGet]
        public Task<JObject> GetDataFromFacebook(string UserName)
        {
            string appPath = "https://social-back.azurewebsites.net/facebook/" + UserName;

            //#if DEBUG
            //    appPath = Path.Combine(@"C:\", @"ScrapperScripts\twitter.py "+ UserName + " --browser chrome");
            //#endif

            return pythonRunner(appPath);
        }

        [Route("GetDataFromGithub/{UserName}")]
        [HttpGet]
        public Task<JObject> GetDataFromGithub(string UserName)
        {
            string appPath = "https://social-back.azurewebsites.net/github/" + UserName;

            //#if DEBUG
            //    appPath = Path.Combine(@"C:\", @"ScrapperScripts\twitter.py "+ UserName + " --browser chrome");
            //#endif

            return pythonRunner(appPath);
        }

        [Route("GetDataFromInstagram/{UserName}")]
        [HttpGet]
        public Task<JObject> GetDataFromInstagram(string UserName)
        {
            string appPath = "https://social-back.azurewebsites.net/instagram/" + UserName;

            //#if DEBUG
            //    appPath = Path.Combine(@"C:\", @"ScrapperScripts\twitter.py "+ UserName + " --browser chrome");
            //#endif

            return pythonRunner(appPath);
        }

        [Route("GetDataFromPinterest/{UserName}")]
        [HttpGet]
        public Task<JObject> GetDataFromPinterest(string UserName)
        {
            string appPath = "https://social-back.azurewebsites.net/Pinterest/" + UserName;

            //#if DEBUG
            //    appPath = Path.Combine(@"C:\", @"ScrapperScripts\twitter.py "+ UserName + " --browser chrome");
            //#endif

            return pythonRunner(appPath);
        }

        [Route("GetDataFromQuora/{UserName}")]
        [HttpGet]
        public Task<JObject> GetDataFromQuora(string UserName)
        {
            string appPath = "https://social-back.azurewebsites.net/Quora/" + UserName;

            //#if DEBUG
            //    appPath = Path.Combine(@"C:\", @"ScrapperScripts\twitter.py "+ UserName + " --browser chrome");
            //#endif

            return pythonRunner(appPath);
        }
        [Route("GetDataFromReddit/{UserName}")]
        [HttpGet]
        public Task<JObject> GetDataFromReddit(string UserName)
        {
            string appPath = "https://social-back.azurewebsites.net/reddit/" + UserName;

            //#if DEBUG
            //    appPath = Path.Combine(@"C:\", @"ScrapperScripts\twitter.py "+ UserName + " --browser chrome");
            //#endif

            return pythonRunner(appPath);
        }

        [Route("GetDataFromTikTok/{UserName}")]
        [HttpGet]
        public Task<JObject> GetDataFromTikTok(string UserName)
        {
            string appPath = "https://social-back.azurewebsites.net/tiktok/" + UserName;

            //#if DEBUG
            //    appPath = Path.Combine(@"C:\", @"ScrapperScripts\twitter.py "+ UserName + " --browser chrome");
            //#endif

            return pythonRunner(appPath);
        }

        public static async Task<JObject> pythonRunner(string command)
        {
            ////string[] files = File.ReadAllLines(appPath);
            //Process p = new Process();
            //p.StartInfo = new ProcessStartInfo("python", command)
            //{
            //    RedirectStandardOutput = true,
            //    UseShellExecute = false,
            //    CreateNoWindow = false
            //};
            //p.Start();

            //string output = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://social-back.azurewebsites.net/twitter/barackObama");
            response.EnsureSuccessStatusCode();
            string output = await response.Content.ReadAsStringAsync();

            JObject jsonOutput = new JObject();
            if (output.Contains("Message: no such element") || !IsValidJson(output))
            {
                string nullMessage = JsonConvert.SerializeObject(new
                {
                    results = new List<string>()
                    {
                    "Please enter another UserName"
                    }
                });
                jsonOutput = JObject.Parse(nullMessage);
            }
            else
            {
                jsonOutput = JObject.Parse(output);
            }

            return jsonOutput;
        }
        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false; }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
