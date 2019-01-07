using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ValueChain.Models;
using ValueChain.Service;
using ValueChain.ViewModels;
using ValueChainModel;

namespace ValueChain.Controllers
{
    public class OffTakersController : BaseController       
    {

        // GET: OffTakers
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetIndex()
        {
            // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            var message = await _db.OffTakers.ToListAsync();
            var data = message.Select(s => new
            {
                s.FullName,
                s.PhoneNumber,
                s.HouseChoice,
                s.LoanApplicable,
                s.HomeAffordability,
                s.GrossIncome,
                s.OffTakerId
            });
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult Create()
        {
            return PartialView();
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

        public PartialViewResult UploadOffTakers()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<ActionResult> UploadOffTakers(HttpPostedFileBase excelfile)
        {
            if (excelfile == null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Please Select an excel file <br/>";
                ViewBag.Message = "You must select an excel file before you click Upload button";
                return View("Index");
            }
            HttpPostedFileBase file = Request.Files["excelfile"];
            if (excelfile.FileName.EndsWith("xls", System.StringComparison.CurrentCulture)
                        || excelfile.FileName.EndsWith("xlsx", System.StringComparison.CurrentCulture))
            {
                string lastrecord = "";
                int recordCount = 0;
                string message = "";
                string fileContentType = file.ContentType;
                byte[] fileBytes = new byte[file.ContentLength];
                var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                // Read data from excel file
                using (var package = new ExcelPackage(file.InputStream))
                {
                    ExcelValidation myExcel = new ExcelValidation();
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    int requiredField = 17;

                    string validCheck = myExcel.ValidateExcel(noOfRow, workSheet, requiredField);
                    if (!validCheck.Equals("Success"))
                    {

                        string[] sizes = validCheck.Split(' ');
                        string[] myArray = new string[2];
                        for (int i = 0; i < sizes.Length; i++)
                        {
                            myArray[i] = sizes[i];
                        }
                        string lineError = $"Line/Row number {myArray[0]}  and column {myArray[1]} is not rightly formatted, Please Check for anomalies ";
                        return RedirectToAction("Index", "OffTakers", new { message = lineError });
                    }
                    for (int row = 2; row <= noOfRow; row++)
                    {
                        var fullName = workSheet.Cells[row, 1].Value.ToString().Trim();
                        var phoneNumber = workSheet.Cells[row, 2].Value.ToString().Trim();
                        var nhf = workSheet.Cells[row, 3].Value.ToString().Trim();
                        var organizationName = workSheet.Cells[row, 4].Value.ToString().Trim();
                        var gradeLevel = workSheet.Cells[row, 5].Value.ToString().Trim();
                        var houseChoice = workSheet.Cells[row, 6].Value.ToString().Trim();
                        var age = workSheet.Cells[row, 7].Value.ToString().Trim();
                        var rate = workSheet.Cells[row, 8].Value.ToString().Trim();
                        var loanApplicable = workSheet.Cells[row, 9].Value.ToString().Trim();
                        var repayment = workSheet.Cells[row, 10].Value.ToString().Trim();
                        var dti = workSheet.Cells[row, 11].Value.ToString().Trim();
                        var netIncome = workSheet.Cells[row, 12].Value.ToString().Trim();
                        var grossIncome = workSheet.Cells[row, 13].Value.ToString().Trim();
                        var tenor = workSheet.Cells[row, 14].Value.ToString().Trim();
                        var homeAffordability = workSheet.Cells[row, 15].Value.ToString().Trim();
                        var equity = workSheet.Cells[row, 15].Value.ToString().Trim();
                        var match = workSheet.Cells[row, 16].Value.ToString().Trim();

                        bool matched = false;

                        if (match.ToUpper().Equals("YES"))
                        {
                            matched = true;
                        }
                        //if (dateOfBirth.Trim().Equals("."))
                        //{
                        //    dob = null;
                        //}
                        //else
                        //{
                        //    dob = Convert.ToDateTime(dateOfBirth);
                        //}
                        try
                        {
                            var model = new OffTaker()
                            {
                                FullName = fullName,
                                Age = Convert.ToInt32(age),
                                NHFNumber = nhf,
                                OrganizationName = organizationName,
                                GradeLevel = gradeLevel,
                                HouseChoice = houseChoice,
                                PhoneNumber = phoneNumber,
                                Rate = Convert.ToInt32(rate),
                                LoanApplicable = Convert.ToDecimal(loanApplicable),
                                Repayment =Convert.ToDecimal(repayment),
                                DTI=Convert.ToDouble(dti),
                                NetIncome=Convert.ToDecimal(netIncome),
                                GrossIncome=Convert.ToDecimal(grossIncome),
                                Tenor=Convert.ToInt32(tenor),
                                HomeAffordability=Convert.ToDecimal(homeAffordability),
                                Equity=Convert.ToDecimal(equity),
                                Matched= matched
                            };
                            _db.OffTakers.Add(model);
                            recordCount++;
                            lastrecord = $"The last record uploaded has the Fullname {fullName}";
                        }
                        catch (Exception ex)
                        {
                            return RedirectToAction("Index", "OffTakers", new { message = ex.Message });
                        }
                    }
                    try
                    {
                        await _db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {

                        message = ex.Message;
                    }

                    message = $"You have successfully Uploaded {recordCount} records...  and {lastrecord}";

                }
                return RedirectToAction("Index", "OffTakers", new { message = message });
            }
            return RedirectToAction("Index", "OffTakers", new { message = ViewBag.Error = $"File type is Incorrect <br/>" });

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
