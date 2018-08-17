using MagicNeinBall.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagicNeinBall.Controllers
{
    public class HomeController : Controller
    {
        //int previousIndex = -1;

        FortuneDBContext _db = new FortuneDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFortune()
        {
            //var model = _db.Fortunes.ToList();

            Random r = new Random();

            //Get count of rows in DB
            var fortuneCountQry = (
                from f in _db.Fortunes
                select f).Count();

            int index = r.Next(1, fortuneCountQry + 1);
            
            //select random row from DB
            var modelQry = (
                from f in _db.Fortunes
                where f.Id == index
                select f).First();

            //Check that this row was not the previously selected by the previous RNG
            //If it was, pick a new RNG. 
            //If this RNG is different from the last, reset the DB variable that keeps track of when the row was picked
            //Qry to find the new entry at the new RNG
            //***NOT RELIABLE***
            //this only accounts for getting the same RNG number 2x in a row, but acts weird if you get the same RNG later
            while(index == modelQry.rIndex)
            {
                index = r.Next(1, fortuneCountQry);
                if (index != modelQry.rIndex)
                {
                    modelQry.rIndex = 0;
                    modelQry = (
                        from f in _db.Fortunes
                        where f.Id == index
                        select f).First();
                    break;
                }
            }

            //flag that this DB row was just picked by the RNG
            modelQry.rIndex = index;
            _db.SaveChanges();


            var model = 
                from f in _db.Fortunes
                where f.Id == index
                select f;

            return PartialView("_Fortune", model);
        }
        

        public ActionResult GetFortune1(Fortune fortuneCurrent)
        {

            var model = new Fortune();

            Random r = new Random();

            List<string> fortuneList = new List<string>();
            fortuneList.Add("Test1");
            fortuneList.Add("I");
            fortuneList.Add("W");
            fortuneList.Add("Y");
            fortuneList.Add("G");
            fortuneList.Add("I");
            fortuneList.Add("C");
            fortuneList.Add("Test2");

            int index = r.Next(0, fortuneList.Count);
        

            //while(index == previousIndex)
            //{
            //    index = r.Next(0, fortuneList.Count);

            //    if (index != previousIndex)
            //        break;
            //}
            
            //fortuneCurrent.fortuneText = fortuneList[index];
            //previousIndex = index;

            model.fortuneText = fortuneList[index];
            fortuneCurrent.fortuneText = model.fortuneText;

            return PartialView("_Fortune", model);
        }
        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}