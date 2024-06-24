using System.Runtime.CompilerServices;
using Bills.Models;
using System.Text.Json;
using System.Net.WebSockets;
//using AspNetCore;

namespace Bills.Services
{
    public class BillsApiService
    {
        public string apiURl = "https://bills-api.parliament.uk";
        public BillsApiService() { }

        public async Task<string> GetAllBills(int session = 38, string searchTerm="", int skip = 0, int take = 100, string sort = "DateUpdatedDescending")
        {
            string url = string.Format("{0}/api/v1/Bills?Session={1}&SortOrder={2}&Skip={3}&Take={4}&SearchTerm={5}", apiURl, session, sort, skip, take,searchTerm);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "text/plain");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();

            return responseObjects;
        }

        public async Task<BillPublication> GetBillPublication(int billId)
        {
            string url = string.Format("{0}/api/v1/Bills/{1}/Publications", apiURl, billId);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "text/plain");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();
            BillPublication billPublication = JsonSerializer.Deserialize<BillPublication>(responseObjects);
            return billPublication;

        }
        public async Task<string> GetBill(int billId)
        {
            string url = string.Format("{0}/api/v1/Bills/{1}", apiURl, billId);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "text/plain");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();

            return responseObjects;
        }

        public async Task<string> GetAllStages()
        {
            ///api/v1/Stages?Skip=0&Take=50
            ///
            string url = string.Format("{0}/api/v1/Stages?Skip=0&Take=50", apiURl);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "text/plain");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();

            return responseObjects;

        }

        public async Task<List<Stage>> GetStages()
        {
            var response = await this.GetAllStages();
            Stages stageList = JsonSerializer.Deserialize<Stages>(response);
            return stageList.items;

        }

        public async Task<string> GetBillStages(int billId, int skip=0, int take=50)
        {
            string url = string.Format("{0}/api/v1/Bills/{1}/Stages?Skip={2}&Take={3}", apiURl, billId, skip,take);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "text/plain");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();

            return responseObjects;
        }

        public async Task<List<BillStage>> GetBillStageById(int billId, int stageId, int skip = 0, int take = 50)
        {
            string url = string.Format("{0}/api/v1/Bills/{1}/Stages?Skip={2}&Take={3}", apiURl, billId, skip, take);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "text/plain");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();
            var billStages = JsonSerializer.Deserialize<BillStages>(responseObjects);
            List<BillStage> relevantStages = new List<BillStage>();
            if (billStages.items != null)
            {
                relevantStages = billStages.items.Where(x => x.stageId == stageId).ToList();
            }
            else
            {
                relevantStages = billStages.items;
            }

            return relevantStages;
        }

        public async Task<List<Amendment>> GetBillAmendments(int billId, IEnumerable<int> stageIds)
        {
            List<Amendment> amendments = new List<Amendment>();
            foreach (var stageId in stageIds)
            {
                amendments.AddRange(await GetBillStageAmendments(stageId, billId));
            }
            return amendments;
        }

        public async Task<AmendmentDetails> GetAmendmentDetails(int billId, int stageId, int amendmentId)
        {
            //AmendmentDetails amendments = new AmendmentDetails();
            string url = string.Format("{0}/api/v1/Bills/{1}/Stages/{2}/Amendments/{3}", apiURl, billId, stageId, amendmentId);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "text/plain");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();
            var amendments = JsonSerializer.Deserialize<AmendmentDetails>(responseObjects);

            return amendments;
        }

        public async Task<List<Amendment>> GetBillStageAmendments (int stageId, int billId, int skip=0, int take=50)
        {

            List<Amendment> amendmentList = new List<Amendment>();
            Amendments amendments = await GetBillStageAmendmentsBase(stageId, billId, skip, take,0, amendmentList);

            return amendmentList;
        }

        public async Task<Amendments> GetBillStageAmendmentsBase(int stageId, int billId, int skip = 0, int take = 50, int recursive = 0, List<Amendment>? amendmentList=null, string searchTerm="",string decision="")
        {
            string url = string.Format("{0}/api/v1/Bills/{1}/Stages/{2}/Amendments?Skip={3}&Take={4}&SearchTerm={5}&Decision={6}", apiURl, billId, stageId, skip, take,searchTerm,decision);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "text/plain");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();

            var amendments = JsonSerializer.Deserialize<Amendments>(responseObjects);
            Console.WriteLine(url);
            Console.WriteLine("amendments ^ is " + amendments.items.Count());

            if (amendments.items != null && amendments.items.Any())
            {
                amendmentList.AddRange(amendments.items);

                if (amendments.itemsPerPage < amendments.totalResults && amendmentList.Count < amendments.totalResults)
                {
                    recursive = recursive + 1;
                    skip = recursive * amendments.itemsPerPage;
                    amendments = await GetBillStageAmendmentsBase(stageId, billId, skip, take, recursive, amendmentList, searchTerm, decision);
                }
                else
                {
                    amendments.items = amendmentList;
                }
            }

            return amendments;

        }
        public async Task<List<Amendment>> GetBillAmendmentsAndStages(int billId, BillStages stages)
        {
            List<Amendment> amendments = new List<Amendment>();
            foreach (var stage in stages.items)
            {
                var tempAmendments = await GetBillStageAmendmentsDesc(stage.id, billId, stage.description + " - " + stage.house+"^"+stage.stageId);
                amendments.AddRange(tempAmendments);
            }
            return amendments;
        }

        public async Task<List<Amendment>> GetBillStageAmendmentsDesc(int stageId, int billId, string stageDesc, int skip = 0, int take = 50)
        {

            List<Amendment> amendmentList = new List<Amendment>();
            Amendments amendments = await GetBillStageAmendmentsBase(stageId, billId, skip, take, 0, amendmentList);
            amendments.items.ForEach(item => { item.stageName = stageDesc; });

            return amendmentList;
        }

    }
}
