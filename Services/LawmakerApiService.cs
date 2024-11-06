using System.Runtime.CompilerServices;
using Lawmaker.Models;
using System.Text.Json;
using System.Net.WebSockets;
using System.Web;
using System.Net;
//using AspNetCore;

namespace Bills.Services
{
    public class LawmakerApiService
    {
        public string apiURl = "https://lawmaker.legislation.gov.uk/pdr";

        public string apiURlstaging = "https://lawmaker.staging.legislation.gov.uk/pdr";

        public Microsoft.AspNetCore.Http.IRequestCookieCollection cookies;
        public LawmakerApiService(Microsoft.AspNetCore.Http.IRequestCookieCollection Cookies) { 

            cookies = Cookies;
        }

        public async Task<string> Login(string username, string password, string existingToken="", string environment="")
        {
            Console.WriteLine("Environment " + environment);
            string url = string.Format("{0}/login", GetApiUrl(environment));
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
                        string url = string.Format("{0}/session/getExpire", GetApiUrl());
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

        public async Task<string> ConnectDocSpace(string authToken, string username="", string password="", string environment="")
        {
            Console.WriteLine(environment);
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, string.Format("{0}/docspace/connect",GetApiUrl(environment)));
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
            var useUrl = string.Format("{0}/ids?docTypes={1}&filter={2}",GetApiUrl(), type,filter);
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
            var useUrl = string.Format("{0}/{1}/all",GetApiUrl(), projectId);
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
            var useUrl = string.Format("{0}/{1}/amendments",GetApiUrl(), projectId);
            var request = new HttpRequestMessage(HttpMethod.Get, useUrl);
            request.Headers.Add("X-Auth-Token", authToken);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("objects returned " + responseObjects);
            return responseObjects;
        }

        public async Task<string> GetDocument(string path, string authToken)
        {
            var client = new HttpClient();
            var useUrl = path;
            var request = new HttpRequestMessage(HttpMethod.Get, useUrl);
            request.Headers.Add("X-Auth-Token", authToken);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseObjects = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("objects returned " + responseObjects);
            return responseObjects;
        }
        /** The environment variable overrides the cookie **/
        public string GetApiUrl(string environment="")
        {
            string UrlToUse = apiURlstaging;
            var cookieEnv = cookies["LawmakerEnvironment"];
            Console.WriteLine("cookie has " + cookieEnv);
            Console.WriteLine("enviroment var has " + environment);

            if(environment != "")
            {
                if(environment == "staging")
                {
                    UrlToUse =  apiURlstaging;
                }
                if(environment == "production")
                {
                    UrlToUse =  apiURl;
                }
            }
            else
            {
                if(cookieEnv == "staging")
                {
                    UrlToUse =  apiURlstaging;
                }
                if(cookieEnv == "production")
                {
                    UrlToUse =  apiURl;
                }
            }

        
            return UrlToUse ;

        }
    }

    
}