using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ValueChain.Models;
using ValueChain.ViewModels;
using ValueChainModel;

namespace ValueChain.Controllers
{
    public class OffTakersController : BaseController       
    {

        // GET: OffTakers
        public ActionResult Index()
        {
            return View(_db.OffTakers.ToList());
        }

        // GET: OffTakers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffTaker offTaker = _db.OffTakers.Find(id);
            if (offTaker == null)
            {
                return HttpNotFound();
            }
            return View(offTaker);
        }

        // GET: OffTakers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OffTakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OffTakerId,FullName,NHFNumber,OrganizationName,GradeLevel,Age,PhoneNumber,HouseChoice,Rate,LoanApplicable,Repayment,DTI,NetIncome,GrossIncome,Tenor,HomeAffordability,Equity,Matched")] OffTaker offTaker)
        {
            if (ModelState.IsValid)
            {
                _db.OffTakers.Add(offTaker);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offTaker);
        }

        // GET: OffTakers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffTaker offTaker = _db.OffTakers.Find(id);
            if (offTaker == null)
            {
                return HttpNotFound();
            }
            return View(offTaker);
        }

        // POST: OffTakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OffTakerId,FullName,NHFNumber,OrganizationName,GradeLevel,Age,PhoneNumber,HouseChoice,Rate,LoanApplicable,Repayment,DTI,NetIncome,GrossIncome,Tenor,HomeAffordability,Equity,Matched")] OffTaker offTaker)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(offTaker).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offTaker);
        }

        // GET: OffTakers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OffTaker offTaker = _db.OffTakers.Find(id);
            if (offTaker == null)
            {
                return HttpNotFound();
            }
            return View(offTaker);
        }

        // POST: OffTakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OffTaker offTaker = _db.OffTakers.Find(id);
            _db.OffTakers.Remove(offTaker);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OffTakersAnalysis()
        {
            var offTakers = _db.OffTakers.ToList();
            var offTakersAnalysisVm = new OffTakersAnalysisVm
            {
                OrganizationCode = "VON",
                OrganizationName = "Voice Of Nigeria",
                StudioAptEquityCount = offTakers.Where(x => x.HouseChoice.Contains(HouseType.StudioAptEquity)).Count(),
                StudioAptCount = offTakers.Where(x => x.HouseChoice.Contains(HouseType.StudioApt)).Count(),
                OneBedRmCount = offTakers.Where(x => x.HouseChoice.Contains(HouseType.OneBedRm)).Count(),
                TwoBedRmCount = offTakers.Where(x => x.HouseChoice.Contains(HouseType.TwoBedRm)).Count(),
                ThreeBedRmCount = offTakers.Where(x => x.HouseChoice.Contains(HouseType.ThreeBedRm)).Count(),
                FourBedRmDuplexCount = offTakers.Where(x => x.HouseChoice.Contains(HouseType.FourBedRm)).Count(),
                ChoiceAffordabilityMatchStudioAptEquityCount = offTakers.Where(x => x.HomeAffordability < 3000000).Count(),
                ChoiceAffordabilityMatchStudioAptCount = offTakers.Where(x => x.HomeAffordability >= 3000000 && (x.HomeAffordability < 4000000)).Count(),
                ChoiceAffordabilityMatchOneBedRmCount = offTakers.Where(x => x.HomeAffordability >= 4000000 && (x.HomeAffordability < 6000000)).Count(),
                ChoiceAffordabilityMatchTwoBedRmCount = offTakers.Where(x => x.HomeAffordability >= 6000000 && (x.HomeAffordability < 8000000)).Count(),
                ChoiceAffordabilityMatchThreeBedRmCount = offTakers.Where(x => x.HomeAffordability >= 8000000 && (x.HomeAffordability < 12000000)).Count(),
                ChoiceAffordabilityMatchFourBedDuplexCount = offTakers.Where(x => x.HomeAffordability > 15000000).Count(),
                ChoiceAffordabilityMatchTotalCount = offTakers.Where(x => x.HomeAffordability < 3000000).Count() + 
                offTakers.Where(x => x.HomeAffordability >= 3000000 && (x.HomeAffordability < 4000000)).Count() + 
                offTakers.Where(x => x.HomeAffordability >= 4000000 && (x.HomeAffordability < 6000000)).Count() + 
                offTakers.Where(x => x.HomeAffordability >= 6000000 && (x.HomeAffordability < 8000000)).Count() +
                offTakers.Where(x => x.HomeAffordability >= 8000000 && (x.HomeAffordability < 12000000)).Count() +
                offTakers.Where(x => x.HomeAffordability > 15000000).Count()
            };

            return View(offTakersAnalysisVm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
