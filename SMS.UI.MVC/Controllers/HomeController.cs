using System.Web.Mvc;
using SMS.UI.MVC.Models;
using System.Net;
using System.Net.Mail;



namespace SMS.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Courses()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel usersContactRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(usersContactRequest);
            }

            //mail message is taking 4 params below, can see when you hover over
            //diff variations of mail message can be modified through those different params 
            MailMessage msg = new MailMessage("admin@yourdomain.com", "standingbytocopy@gmail.com", usersContactRequest.Subject,
            usersContactRequest.Message);

            msg.CC.Add("yourccemail@gmail.com");

            SmtpClient client = new SmtpClient("mail.yourdomain.com");
            client.Credentials = new NetworkCredential("admin@yourdomain.com", "Admin@123456");

            client.Port = 8889;

            try
            {
                client.Send(msg);
            }
            catch (System.Exception ex)
            {
                ViewBag.ErrorMessage = "There was techmologie differentials" + ex.StackTrace;
                return View(usersContactRequest);
            }

            return View("EmailConfirmation", usersContactRequest);  //send the user to a email conformation view

        }

    }
}
