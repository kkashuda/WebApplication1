using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class JobsController : Controller
    {
        private JobDBContext db = new JobDBContext();

        // GET: Jobs
        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        
    }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employer,Title,Description,Email,PayRate,City,State,ZipCode")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        
        // GET: Jobs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        
        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employer,Title,Description,Email,PayRate,City,State,ZipCode")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /*
        *
            {0} First Name
            {1} Last Name
            {2} Applicant's Email
            {3} Permanent Address
            {4} Phone Number
            {5} Previous Work Experience
            {6} Relevant Skills
            {7} Additional Comments
        *
        */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Details(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p><strong>Email From:</strong> {0} {1} ({2} | {4})</p><p><strong>Address:</strong> {3}</p><p><strong>Previous Work Experience</strong></p><p>{5}</p><p><strong>Relevant Skills:</strong></p><p>{6}</p><p><strong>Additional Comments:</strong></p><p>{7}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(Session["eEmail"] as string));  // replace with Employer email
                message.From = new MailAddress("azure_44942b7045ba921d2d3d28e51f4cb8c5@azure.com");  // replace with from email
                message.Subject = "GeoJob | Job Application Submission";
                message.Body = string.Format(body, model.FirstName, model.LastName, model.FromEmail, model.PermanentAddress, model.PhoneNumber, model.WorkExperience, model.Skills, model.AdditionalComments);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "azure_44942b7045ba921d2d3d28e51f4cb8c5@azure.com",  // replace with valid value
                        Password = "PJ7sw43N8Ev77L2"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.sendgrid.net";
                    smtp.Port = 25;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Sent()
        {
            return View();
        }

        public ActionResult Apply()
        {
            return View();
        }
    }
}
