using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using IdentityProject.Models;
using Facebook;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace IdentityProject.Controllers
{
    public class FacebookDataController : Controller
    {

        [HttpPost]
        public  ActionResult ShareToFacebook(string FilePath)
        {
            string UserAccessToken = ConfigurationManager.AppSettings["FacebookAccessToken"].ToString();
            string message = "having fun";
            string title = "hi";
            string filePath =  FilePath;
            byte[] returnBytes=null;
            if (!string.IsNullOrEmpty(UserAccessToken))
            {
                string FileUploadUrl = string.Format("https://graph-video.facebook.com/me/videos?title={0}&description={1}&access_token={2}", HttpUtility.UrlEncode(message), HttpUtility.UrlEncode(title), UserAccessToken);
                WebClient uploadClient = new WebClient();
                 returnBytes =  uploadClient.UploadFile(FileUploadUrl, filePath);
            }
             return View();
        }
        [HttpGet]
        public ActionResult ShareToFacebook()
        {
            ViewBag.Filepath = null;
            return View();
        }
    }
}