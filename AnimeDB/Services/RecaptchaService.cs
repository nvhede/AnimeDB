using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimeDB.Services
{
    public class RecaptchaService
    {
        public bool Success { get; set; }
        public List<string> ErrorCodes { get; set; }

        public static bool Validate(string response, string key)
        {
            if (string.IsNullOrEmpty(response) || string.IsNullOrEmpty(key))
            {
                return false;
            }

            var client = new System.Net.WebClient();
            var secret = key;

            var googleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var reCaptcha = serializer.Deserialize<RecaptchaService>(googleReply);
            return reCaptcha.Success;
        }
}