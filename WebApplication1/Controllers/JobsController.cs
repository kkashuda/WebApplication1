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
            //return View(job);
            var tuple = new Tuple<Job, ContactViewModel>(job, new ContactViewModel());
            return View(tuple);
        
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

        [HttpPost]
        public async Task<ActionResult> Contact(ContactViewModel vm)
        {/*
            if (!ModelState.IsValid)
            {
                return View();
            }
            */
            //Send Email
            var message = new MailMessage();
            message.To.Add(new MailAddress("shedges1995@gmail.com"));  // replace with valid value 
            message.From = new MailAddress("shedges1995@gmail.com");  // replace with valid value
            message.Subject = "Thanks for your message!";
            message.Body = string.Format("<p><b>From:</b> {0} ({1})</p><p><b>Mesage:</b> {2}</p>", vm.Name, vm.Email, vm.Message);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "shedges1995@gmail.com",  // replace with valid value
                    Password = "inuyasha12"  // replace with valid value
                   
                   

            };
                smtp.Credentials = credential;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 465;
                //smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
            }


            return View("Details");
        }
    }
}
