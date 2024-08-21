using System.Runtime.CompilerServices;
using Lawmaker.Models;
using System.Text.Json;
using System.Net.WebSockets;
//using AspNetCore;

namespace Bills.Services
{
    public class LawmakerApiService
    {
        public string apiURl = "https://lawmaker.staging.legislation.gov.uk/pdr";
        public LawmakerApiService() { }

        public async Task<string> Login(string username, string password, string existingToken="")
        {
            string url = string.Format("{0}/login", apiURl);
            var client = new HttpClient();
            
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("username", username));
            collection.Add(new("password", password));
            collection.Add(new("refreshToken",existingToken));
            collection.Add(new("ds", "LEGI_PDR"));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            request.Headers.Add("Accept", "application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();

            return responseObjects;
        }

        public async Task<string> CheckRemainingSession(string token)
        {
            //throw new NotImplementedException();1532143144
                        string url = string.Format("{0}/session/getExpire", apiURl);
            var client = new HttpClient();
            
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("X-Auth-Token", token);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response : " + responseObjects);
            return responseObjects;
        }

        public async Task<string> ConnectDocSpace(string authToken, string username="", string password="")
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, string.Format("{0}/docspace/connect",apiURl));
            request.Headers.Add("X-Auth-Token",authToken);
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("username", username));
            collection.Add(new("password", password));
            collection.Add(new("ds", "LEGI_PDR"));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();
            return responseObjects;
        }
        public async Task<string> GetBillList(string authToken, string type, string filter="")
        {
            var client = new HttpClient();
            var useUrl = string.Format("{0}/ids?docTypes={1}&filter={2}",apiURl, type,filter);
            var request = new HttpRequestMessage(HttpMethod.Get, useUrl);
            request.Headers.Add("X-Auth-Token", authToken);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();
            return responseObjects;
        }
        public async Task<string> GetBill(string projectId, string authToken)
        {
            var client = new HttpClient();
            var useUrl = string.Format("{0}/{1}/all",apiURl, projectId);
            var request = new HttpRequestMessage(HttpMethod.Get, useUrl);
            request.Headers.Add("X-Auth-Token", authToken);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();
            return responseObjects;
        }
        public async Task<string> GetBillAmendments(string projectId, string authToken)
        {
            var client = new HttpClient();
            var useUrl = string.Format("{0}/{1}/amendments",apiURl, projectId);
            var request = new HttpRequestMessage(HttpMethod.Get, useUrl);
            request.Headers.Add("X-Auth-Token", authToken);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();
            Console.WriteLine("objects returned " + responseObjects);
            return responseObjects;
        }
    }

    
}