using System.Runtime.CompilerServices;
using Bills.Models;
using System.Text.Json;
using System.Net.WebSockets;
using NuGet.Protocol.Plugins;
//using AspNetCore;

namespace Bills.Services
{

    public class OrderPaperService
    {
        public string apiKey = "e16ca3cd-8645-4076-aaba-3f1f31028da1";
        public string apiURl = "https://services.orderpaper.parliament.uk";
        public OrderPaperService() {}

        public async Task<string> GetBusinessItems(DateTime from, DateTime to, string type="", bool withDate = true, string iFormat = "json")
        {
            var itemUrl = apiURl;
            if(withDate)
            {
                itemUrl = itemUrl + "/businessitems/tableditemswithdate." + iFormat;
            }
            if(!withDate)
            {
                itemUrl = itemUrl + "/businessitems/tableditemswithoutdate." +iFormat;
            }
            var dateString = "&fromDate=" + from.ToString("yyyy-MM-dd") + "&toDate=" +to.ToString("yyyy-MM-dd");
            itemUrl = string.Format(itemUrl+"?key={0}{1}{2}",apiKey,dateString,type);

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, itemUrl);
            request.Headers.Add("Accept", "text/plain");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();

            return responseObjects;


        }


    }
}