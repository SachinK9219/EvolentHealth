using EvolentHealthUI.DataAccessLayer;
using EvolentHealthUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvolentHealthUI.Controllers
{
    public class ContactController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ContactController));
        // GET: Contact
        ContactDataAccess contactda = new ContactDataAccess();
        List<Contact> contactList = new List<Contact>();


        //[ValidateAntiForgeryToken]
        public ActionResult GetALL()
        {

            var data = contactda.GetALL();
            Session["ListData"] = data;
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                bool Result = contactda.InsertData(contact);

                if (Result)
                    return RedirectToAction("GetALL");

            }
            return View();


        }

        //[ValidateAntiForgeryToken]
        public ActionResult Edit(string id)
        {
            var data = Session["ListData"] as List<Contact>;

            var EditData = data.Where(y => y.ID.Equals(id)).FirstOrDefault();

            return View(EditData);
        }
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                bool Result = contactda.UpdateData(contact);

                if (Result)
                    return RedirectToAction("GetALL");
            }
            return View();
        }
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            var data = Session["ListData"] as List<Contact>;
            var DeleteData = data.Where(y => y.ID.Equals(id)).FirstOrDefault();
            return View(DeleteData);
        }


        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(Contact contact)
        {

            bool Result = contactda.DeleteData(contact.ID);

            return RedirectToAction("GetALL");
        }

        //[ValidateAntiForgeryToken]
        public ActionResult Details(string id)
        {
            var Data = Session["ListData"] as List<Contact>;
            var DetailsData = Data.Where(y => y.ID.Equals(id)).FirstOrDefault();
            return View(DetailsData);
        }
    }
}