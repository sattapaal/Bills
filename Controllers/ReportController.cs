using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bills.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetBillsAndAmendments(int session = 38, string searchTerm = "", int skip=0, int take=100, bool omitTotals = false, bool asJson=false)
        {
            TempData["startTime"] = DateTime.Now;
            List<BillSummary> bills = new List<BillSummary>();

            BillsApiService billsApiService = new BillsApiService();
            var allBills= await billsApiService.GetAllBills(session,searchTerm,skip,take);

            Models.Bills returnedBills = JsonSerializer.Deserialize<Models.Bills>(allBills);
            foreach (var bill in returnedBills.items)
            {
                BillSummary summary = new BillSummary();
                summary.BillId = bill.billId;
                summary.Name = bill.shortTitle;
                summary.Stage = bill.currentStage.description;
                summary.DateModified = bill.lastUpdate;
                
                bills.Add(summary);
            }
            List<BillSummary> billsWithAmendments = new List<BillSummary>();
            foreach(var bill in bills)
            {
                var response = await billsApiService.GetBillStages(bill.BillId);
                BillStages billStages = JsonSerializer.Deserialize<BillStages>(response);
                bill.Amendments = await billsApiService.GetBillAmendmentsAndStages(bill.BillId, billStages);
                bill.AmendmentsByStage = GetStageAmendmentsCount(bill);
                if (!omitTotals)
                {
                    bill.AmendmentCount = GetAmendmentCount(bill);
                }
                billsWithAmendments.Add(bill);
            }
            TempData["endTime"] = DateTime.Now;
            if (asJson)
            {
                return Json(billsWithAmendments);
            }
            else
            {
                return View(billsWithAmendments);
            }
        }
        private BillSummary ProcessBill(BillSummary summary)
        {
            var newSummary = summary;
            newSummary.AmendmentCount = GetAmendmentCount(newSummary);
            newSummary.AmendmentsByStage = GetStageAmendmentsCount(newSummary);
            return newSummary;
        }

        private List<AmendmentCount> GetStageAmendmentsCount(BillSummary summary)
        {

            if (summary.Amendments != null && summary.Amendments.Any())
            {
                List<AmendmentCount> listOfStageAmendments = new List<AmendmentCount>();

                var results = summary.Amendments.GroupBy(x => x.billStageId);
                var totalCount = summary.Amendments.Count();
                foreach (var result in results)
                {
                    AmendmentCount am = new AmendmentCount();
                    am.Stage = result.FirstOrDefault().stageName;
                    am.NoDecision = result.Where(x => x.decision == "NoDecision").Count();
                    am.NotCalled = result.Where(x => x.decision == "NotCalled").Count();
                    am.Agreed = result.Where(x => x.decision == "Agreed").Count();
                    am.NotMoved = result.Where(x => x.decision == "NotMoved").Count();
                    am.Withdrawn = result.Where(x => x.decision == "Withdrawn").Count();
                    am.NegativedOnDivision = result.Where(x => x.decision == "NegativedOnDivision").Count();
                    am.NotSelected = result.Where(x => x.decision == "NotSelected").Count();
                    am.AmendmentTotal = totalCount;
                    listOfStageAmendments.Add(am);

                }
                
                return listOfStageAmendments;
            }
            return null;
        }
        private AmendmentCount GetAmendmentCount(BillSummary summary)
        {
            AmendmentCount amendmentCount = new AmendmentCount();
            amendmentCount.Stage = "Total";
            amendmentCount.NoDecision = summary.Amendments.Where(x => x.decision == "NoDecision").Count();
            amendmentCount.Agreed = summary.Amendments.Where(x => x.decision == "Agreed").Count();
            amendmentCount.NotCalled = summary.Amendments.Where(x => x.decision == "NotCalled").Count();
            amendmentCount.NotMoved = summary.Amendments.Where(x => x.decision == "NotMoved").Count();
            amendmentCount.Withdrawn = summary.Amendments.Where(x => x.decision == "Withdrawn").Count();
            amendmentCount.NegativedOnDivision = summary.Amendments.Where(x => x.decision == "NegativedOnDivision").Count();
            amendmentCount.NotSelected = summary.Amendments.Where(x => x.decision == "NotSelected").Count();
            amendmentCount.AmendmentTotal = summary.Amendments.Count();
            return amendmentCount;
        }

        public IActionResult Search()
        {
            return View();
        }

    }
}
