using Microsoft.AspNetCore.Mvc;
using Bills.Services;
using System.Text.Json.Serialization;
using Bills.Models;
using System.Text.Json;
using System.Linq;


namespace Bills.Controllers
{
    public class BillsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllBills(int session = 38, string searchTerm="", int skip = 0, int take = 50, bool asJson=false)
        {
            TempData["session"] = session;
            BillsApiService billsApiService = new BillsApiService();
            var response = await billsApiService.GetAllBills(session,searchTerm,skip,take);
            Models.Bills returnedBills = JsonSerializer.Deserialize<Models.Bills>(response);
            //JsonConverter<Models.Bills>(response);
            if (asJson)
            {
                return Json(returnedBills);
            }
            else
            {
                return View(returnedBills);
            }
        }

        public async Task<IActionResult> GetBillPublication(int billId)
        {

            BillsApiService billsApiService = new BillsApiService();
            var response = await billsApiService.GetBillPublication(billId);
            return View(response);
        }

        public async Task<IActionResult> GetBillDetails(int billId)
        {
            BillsApiService billsApiService = new BillsApiService();
            var response = await billsApiService.GetBill(billId);
            BillDetails bill = JsonSerializer.Deserialize<BillDetails>(response);
            return View(bill);
        }

        public async Task<IActionResult> GetAllStages()
        {
            BillsApiService billsApiService = new BillsApiService();
            var response = await billsApiService.GetAllStages();
            Stages stages = JsonSerializer.Deserialize<Stages>(response);
            return View(stages);
        }

        public async Task<IActionResult> GetBillStages(int billId, int skip=0, int take=50)
        {
            BillsApiService bcsApiService = new BillsApiService();
            var response = await bcsApiService.GetBillStages(billId,skip,take);
            BillStages billStages = JsonSerializer.Deserialize<BillStages>(response);
            return View(billStages);
        }

        public async Task<IActionResult> GetBillAmendments(int billId, int stageId, int skip=0, int take=50)
        {
            BillsApiService billApiService = new BillsApiService();
            var response = await billApiService.GetBillStages(billId, skip, take);
            BillStages billStages = JsonSerializer.Deserialize<BillStages>(response);

            var stageIds = billStages.items.Select(x=> x.id).ToList();

            var amendments = await billApiService.GetBillAmendments(billId, stageIds);

            return View(amendments);


        }
        public async Task<IActionResult> GetBillAmendmentsAndStage(int billId, int stageId, int skip=0, int take=50)
        {
            BillsApiService billApiService = new BillsApiService();
            var response = await billApiService.GetBillStages(billId, skip, take);
            BillStages billStages = JsonSerializer.Deserialize<BillStages>(response);

            

            var amendments = await billApiService.GetBillAmendmentsAndStages(billId, billStages);

            return View(amendments);
        }

        public async Task<IActionResult> GetAmendmentDetails(int billId, int stageId, int amendmentId)
        {
            BillsApiService billApiService = new BillsApiService();
            var amendments = await billApiService.GetAmendmentDetails(billId, stageId, amendmentId);

            return View(amendments);
        }
        public IActionResult SearchBills()
        {

        return View(); 
        }

        [HttpGet]
        public async Task<IActionResult> SearchBillAmendment()
        {
            SearchBillAmendmentsViewModel billsAndStages = new SearchBillAmendmentsViewModel();
            WhatsOnCalendarApiService calendarApiService = new WhatsOnCalendarApiService();
            var sessions = await calendarApiService.GetSessionsBills();
            Session currentSession = sessions.OrderByDescending(x => x.SessionId).Where(x=> x.StartDate > DateTime.Now && x.EndDate < DateTime.Now).FirstOrDefault();
            
            if(currentSession == null)
            {
                //this means we are either in between sessions are simply not in session. take 2nd to last session
                currentSession = sessions.OrderByDescending(x => x.SessionId).Skip(1).FirstOrDefault(); 
            }
            
            var bs = new BillsApiService();
            billsAndStages.Bills = ConvertToBills(await bs.GetAllBills(currentSession.SessionId, "", 0, 1000));


            billsAndStages.Stages = await bs.GetStages();
            billsAndStages.Stages.Add(new Stage()
            {
                house = "",
                id = 0,
                name = "All"
            });
            billsAndStages.Stages.OrderBy(x=> x.id).ToList();
            billsAndStages.Decisions = Decisions.ToList(); 
            return View(billsAndStages); 
        }

        public async Task<IActionResult> SearchBillAmendments(int billId, int stageId, string amendmentName="", string decision="")
        {
            var bs = new BillsApiService();
            var billStages = await bs.GetBillStageById(billId, stageId);
            List<Amendment> amendments = new List<Amendment>();
            List<Amendment> tempList = new List<Amendment>(); //dispose of this.
            if (billStages != null && billStages.Any())
            {
                foreach (var stage in billStages)
                {
                    var collection = await bs.GetBillStageAmendmentsBase(stage.id, billId, 0, 100, 0, tempList, "",decision);
                    amendments = collection.items;//.AddRange(collection.items);
                    //tempList.Clear();
                }

            }
            else
            {

                    var stages = await bs.GetBillStages(billId);
                    BillStages bStages = JsonSerializer.Deserialize<BillStages>(stages);

                    foreach (var stage in bStages.items)
                    {
                        var collection = await bs.GetBillStageAmendmentsBase(stage.id, billId, 0, 100, 0, tempList, "", decision);
                        if (collection.items != null && collection.items.Any())
                        {
                            collection.items.ForEach(item => item.stageName = stage.description + " - " + stage.house);
                            amendments.AddRange(collection.items);

                        }
                        tempList.Clear();
                    }
            }

            if (amendments != null && amendments.Any())
            {
                if (amendmentName != string.Empty)
                {
                    amendments = amendments.Where(x => x.marshalledListText == amendmentName.Trim()).ToList();
                }
            }

            return View(amendments); 
        }

        private Models.Bills ConvertToBills(string input)
        {
            Models.Bills returnedBills = JsonSerializer.Deserialize<Models.Bills>(input);
            return returnedBills;
        }

        private string[] Decisions = { "","NoDecision","Agreed","NotCalled","NotMoved","Withdrawn","NegativedOnDivision","NotSelected"
        };
    }
}
