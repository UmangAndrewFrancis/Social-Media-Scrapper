using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using socialMediaScrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace socialMediaScrapper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(FormCollection form)
        {
            string userName = form["userName"];
            scrappedUser objScrappedUser = await getScrapUserData(userName);
            return View("UserDetails", objScrappedUser);
        }

        public ActionResult UserDetails()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<scrappedUser> getScrapUserData(string userName)
        {
            string Baseurl = "https://social-back.azurewebsites.net/";
            #if DEBUG
            Baseurl = "https://social-back.azurewebsites.net/";
            #endif
            scrappedTwitterInfo getTwitterInfo = new scrappedTwitterInfo();
            scrappedInstagramInfo getInstagramInfo = new scrappedInstagramInfo();
            scrappedGithubInfo getGitHubInfo = new scrappedGithubInfo ();
            scrappedPinterestInfo getPinterestInfo = new scrappedPinterestInfo();

            scrappedUser scrappedUserInfo = new scrappedUser();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("twitter/" + userName);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var res = Res.Content.ReadAsStringAsync().Result;
                    if (IsValidJson(res))
                    {
                        getTwitterInfo = JsonConvert.DeserializeObject<scrappedTwitterInfo>(res);
                    }
                    else
                    {
                        string nullMessage = JsonConvert.SerializeObject(new
                        {
                            results = new List<string>()
                            {
                            "Please enter another UserName"
                            }
                        });
                        Console.WriteLine("No user exist for this username - twitter");
                    }
                }
            }
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("github/" + userName);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var res = Res.Content.ReadAsStringAsync().Result;
                    if (IsValidJson(res))
                    {
                        getGitHubInfo = JsonConvert.DeserializeObject<scrappedGithubInfo>(res);
                    }
                    else
                    {
                        string nullMessage = JsonConvert.SerializeObject(new
                        {
                            results = new List<string>()
                            {
                            "Please enter another UserName"
                            }
                        });
                        Console.WriteLine("No user exist for this username - GitHub");
                    }
                }
            }
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("instagram/" + userName);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var res = Res.Content.ReadAsStringAsync().Result;
                    if (IsValidJson(res))
                    {
                        getInstagramInfo = JsonConvert.DeserializeObject<scrappedInstagramInfo>(res);
                    }
                    else
                    {
                        string nullMessage = JsonConvert.SerializeObject(new
                        {
                            results = new List<string>()
                            {
                            "Please enter another UserName"
                            }
                        });
                        Console.WriteLine("No user exist for this username - Instagram");
                    }
                }
            }
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("pinterest/" + userName);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var res = Res.Content.ReadAsStringAsync().Result;
                    if (IsValidJson(res))
                    {
                        getPinterestInfo = JsonConvert.DeserializeObject<scrappedPinterestInfo>(res);
                    }
                    else
                    {
                        string nullMessage = JsonConvert.SerializeObject(new
                        {
                            results = new List<string>()
                            {
                            "Please enter another UserName"
                            }
                        });
                        Console.WriteLine("No user exist for this username - Instagram");
                    }
                }
            }

            scrappedUserInfo._scrappedTwitterInfo = getTwitterInfo;
            scrappedUserInfo._scrappedGithubInfo = getGitHubInfo;
            scrappedUserInfo._scrappedInstagramInfo = getInstagramInfo;
            scrappedUserInfo._scrappedPinterestInfo = getPinterestInfo;

            return scrappedUserInfo;
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