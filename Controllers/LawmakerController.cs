using Microsoft.AspNetCore.Mvc;
using Bills.Services;
using System.Text.Json.Serialization;
using Lawmaker.Models;
using System.Text.Json;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Identity;
using System.Xml;
using System.Xml.Serialization;
using System.Text;


namespace Bills.Controllers
{
    public class LawmakerController : Controller
    {
        string? token;
        public async Task<IActionResult> Login()
        {
            
            return View();
        }

        public async Task<IActionResult> SubmitLogin(string username, string password, string existingToken = "")
        {
            existingToken = GetCurrentSession();
            LawmakerApiService lawmakerService = new LawmakerApiService();
            var response = await lawmakerService.Login(username,password,existingToken);
            LoginResponse user = JsonSerializer.Deserialize<LoginResponse>(response);
            token = user.token;
            Response.Cookies.Append("LawmakerSession", user.token, GetCookieOptions());
            return View(user);
        }

        public async Task<IActionResult> SubmitLoginAndConnect(string username, string password, string existingToken = "")
        {
            existingToken = GetCurrentSession();
            LawmakerApiService lawmakerService = new LawmakerApiService();
            var response = await lawmakerService.Login(username,password,existingToken);
            LoginResponse user = JsonSerializer.Deserialize<LoginResponse>(response);
            token = user.token;
            Response.Cookies.Append("LawmakerSession", user.token, GetCookieOptions());

            var docbaseResponse = await lawmakerService.ConnectDocSpace(user.token, username,password);
            ViewBag.Docbase = docbaseResponse;


            return View(user);
        }

        public CookieOptions GetCookieOptions()
        {
            CookieOptions options = new CookieOptions();
            //options.Domain = Request.Host;
            options.Expires = DateTime.Now.AddDays(1);
            options.Path = "/";
            options.SameSite = SameSiteMode.Lax;
            return options;
        }

        public async Task<IActionResult> CheckSessionRemaining(string inToken)
        {
            var sessionCookie = Request.Cookies["LawmakerSession"];
            
            inToken = GetCurrentSession();

            LawmakerApiService lawmakerService = new LawmakerApiService();
            var response = await lawmakerService.CheckRemainingSession(inToken);
            ViewBag.Remaining = response;

            return View();
        }

        public async Task<IActionResult> ConnectDocspace()
        {
            var inToken = GetCurrentSession();
            LawmakerApiService lawmakerApiService = new LawmakerApiService();
            var response = await lawmakerApiService.ConnectDocSpace(inToken);
            ViewBag.Message = response;
            return View();
        }

        public string GetCurrentSession()
        {
            string inToken = "";
            var sessionCookie = Request.Cookies["LawmakerSession"];
            if(!string.IsNullOrEmpty(sessionCookie))
            {
                inToken = sessionCookie;
            }
            else
            {
                if(string.IsNullOrEmpty(token))
                {
                    return "";
                }
                else
                {
                    //shouldnt hit.
                    inToken = token;
                }
            }
            return inToken;
        }

        public IActionResult GetBillListByType()
        {
            return View();
        }

        public async Task<IActionResult> BillList(string type = "", string filter = "")
        {
            Console.WriteLine(type);
            Console.WriteLine(filter);

            LawmakerApiService lawmakerApiService = new LawmakerApiService();
            var results = await lawmakerApiService.GetBillList(GetCurrentSession(),type,filter);
            LawmakerBillList bills = JsonSerializer.Deserialize<LawmakerBillList>(results);
            return View(bills);
        }

        public async Task<IActionResult> ProjectDetails(string projectId)
        {
            LawmakerApiService lawmakerApiService = new LawmakerApiService();
            var results = await lawmakerApiService.GetBill(projectId, GetCurrentSession());
            //Console.WriteLine(projectId + " RESULT " + results);
            Lawmaker.Models.Bill bill = JsonSerializer.Deserialize<Lawmaker.Models.Bill>(results.TrimStart('[').TrimEnd(']'));
            return View(bill);
        }
        public async Task<IActionResult> ProjectAmendments(string projectId)
        {
            LawmakerApiService lawmakerApiService = new LawmakerApiService();
            var results = await lawmakerApiService.GetBillAmendments(projectId, GetCurrentSession());
            //Console.WriteLine(projectId + " RESULT " + results);
            BillAmendments amendments = JsonSerializer.Deserialize<BillAmendments>(results);
            return View(amendments);
        }

        public async Task<ContentResult> GetDocument(string documentPath)
        {
            LawmakerApiService lawmakerApiService = new LawmakerApiService();
            var results = await lawmakerApiService.GetDocument(documentPath, GetCurrentSession());
            Console.WriteLine(documentPath + " RESULT " + results);
            
            return new ContentResult
            {
                Content = results,
                ContentType = "application/xml",
                StatusCode = 200
            };
        }

        public async Task<IActionResult> GetDocumentAsModel(string documentPath)
        {
            LawmakerApiService lawmakerApiService = new LawmakerApiService();
            var results = await lawmakerApiService.GetDocument(documentPath, GetCurrentSession());
            //Console.WriteLine(documentPath + " RESULT " + results);
            //Lawmaker.Models.XML.Amendment amendment = JsonSerializer.Deserialize<Lawmaker.Models.XML.Amendment>(results);
            
            Lawmaker.Models.XML.Amendment amendment = new Lawmaker.Models.XML.Amendment();

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lawmaker.Models.XML.Amendment));
                //
                using (XmlReader reader = XmlReader.Create(GenerateStreamFromString(results)))
                {
                    try
                    {
                        var deserializedResult = xmlSerializer.Deserialize(reader);
                        amendment = (Lawmaker.Models.XML.Amendment) deserializedResult;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex);
                        Console.Write(results);
                    }
                }


            return View(amendment);
        }

        public static MemoryStream GenerateStreamFromString(string value)
        {

            //return new MemoryStream(Encoding.Unicode.GetBytes(value ?? ""));
            return new MemoryStream(Encoding.ASCII.GetBytes(value ?? ""));
            //return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }

    }
}