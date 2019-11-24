using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lab7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //get user
        public JsonResult GetUser()
        {
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["Lab7Token"];
            string uri = "https://api.github.com/user";
            string data = SendRequest(uri, "4456e15d4653f12805e78526362a5bdb9dee642d", "ncastle16");

            JObject test = JObject.Parse(data);
            string name = (string)test["name"].ToString();
            string company = (string)test["company"].ToString();
            string location = (string)test["location"].ToString();
            string avatar = (string)test["avatar_url"].ToString();
            string email = (string)test["email"].ToString();

            var finalData = new
            {
                name = name,
                company = company,
                location = location,
                avatar = avatar,
                email = email
            };

            return Json(finalData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCommits()
        {
            string user = Request.QueryString["user"];
            string repos = Request.QueryString["repo"];
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["Lab7Token"];
            string uri = "https://api.github.com/repos/" + user + "/" + repos + "/commits";
            
            string data = SendRequest(uri, "4456e15d4653f12805e78526362a5bdb9dee642d", user);

            JArray test = JArray.Parse(data);
            List<string> message = new List<string>();
            List<string> name = new List<string>();
            List<string> date = new List<string>();
            int counter = 0;

            foreach (JObject o in test.Children<JObject>())
            {
                message.Add((string)test[counter]["commit"]["message"]);
                name.Add((string)test[counter]["commit"]["author"]["name"]);
                date.Add((string)test[counter]["commit"]["committer"]["date"]);
                counter++;
            }

            var finalData = new
            {
                message = message,
                name = name,
                date = date,
                counter = counter
            };

            return Json(finalData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRepos()
        {
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["Lab7Token"];
            string uri = "https://api.github.com/user/repos";
            string data = SendRequest(uri, "4456e15d4653f12805e78526362a5bdb9dee642d", "ncastle16");

            JArray test = JArray.Parse(data);
            List<string> names = new List<string>();
            List<string> owners = new List<string>();
            List<string> updated = new List<string>();
            List<string> owner = new List<string>();

            int counter = 0;

            foreach (JObject o in test.Children<JObject>()) {
            names.Add((string)test[counter]["name"]);
            owners.Add((string)test[counter]["owner"]["login"]);
            updated.Add((string)test[counter]["updated_at"]);
            counter++;
        }


            var finalData = new
            {
                name = names,
                owner = owners,
                updated = updated,
                counter = counter
            };

            return Json(finalData, JsonRequestBehavior.AllowGet);

        }
        private string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";
            Debug.WriteLine(uri);
            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }
    }
}