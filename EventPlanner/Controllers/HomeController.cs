using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using EventPlanner.Models;
using EventPlanner.DataAccessLayer;
using EventPlanner.DBConnection;

namespace EventPlanner.Controllers
{
    public class HomeController : Controller
    {
        private db datas = new db();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UpcomingEvents()
        {
            //List<AuditPlanDurationModel> auditPlanDurationModelList = iAuditPlanInformation.GetAuditPlanDuration();
            List<UpEventModel> UpEventModelList = null;
            try
            {
                UpEventModelList = datas.UpcomingEvents();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            string output = JsonConvert.SerializeObject(UpEventModelList);
            return Json(output);
        }

        [HttpPost]
        public ActionResult SaveNewEvent(UpEventModel allData)
        {

            var respons = datas.SaveNewEvent(allData);
            string output = JsonConvert.SerializeObject(respons);
            return Json(output);
        }

        [HttpPost]
        public ActionResult GetEventType()
        {
            var eventType = datas.GetEventType();

            string output = JsonConvert.SerializeObject(eventType);
            return Json(output);
        }

        [HttpPost]
        public ActionResult GetEventID()
        {
            var eventID = datas.GetEventID();

            string output = JsonConvert.SerializeObject(eventID);
            return Json(output);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}