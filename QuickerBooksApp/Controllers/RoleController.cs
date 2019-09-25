using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using QuickerBooksApp.Models;
using System.Threading.Tasks;
using System.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using QuickerBooksApp.Models;


namespace QuickerBooksApp.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {


                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);

        }
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Administrator")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            { 


                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        internal class Mail
        {
            private static void Main()
            {

            }

            internal async Task ExecuteAsync(string From, string TO, string subject, string CC, string plainTextContent, string htmlContent)
            {
                var apiKey = ConfigurationManager.AppSettings["SendGridApiKey"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("quickerbooks123@gmail.com", "Admin");
                var to = new EmailAddress(TO);
                var cc = new EmailAddress(CC);
                htmlContent = "<strong>" + htmlContent + "</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
        }


        //
        // GET: Email
        [AllowAnonymous]
        public ActionResult SendGridEmailSubmit(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> SendgridEmailSubmit(EmailViewModel emailmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(emailmodel);
            }

            ViewBag.Message = "Email Sent!!!...";
            Mail emailexample = new Mail();
            await emailexample.ExecuteAsync(emailmodel.From, emailmodel.To, emailmodel.CC, emailmodel.Subject, emailmodel.Body
                , emailmodel.Body);

           // return View("Email");
            return View();
        }
    }

    }
