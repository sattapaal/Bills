using Bills.Models.OrderPaper;
using Bills.Models;
using Bills.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Bills.Controllers
{
    public class OrderPaperController : Controller
    {
        public IActionResult GetAnOrderPaper()
        {
            return View();
        }

        public async Task<IActionResult> GetBusinessItems(DateTime from, DateTime to, string type="", bool withDate = true, string iFormat = "json", string output="html")
        {
            OrderPaperService ops = new OrderPaperService();
            var response = await ops.GetBusinessItems(from, to, type, withDate, iFormat);
            //response comes back XML or JSON

            //if its json, you need to covert to xml, otherwise, convert to json

            if(output=="html")
            {

            BusinessItems businessItems = new BusinessItems();

            if(iFormat=="json")
            {
                businessItems = JsonSerializer.Deserialize<BusinessItems>(response);
            }
            if(iFormat == "xml")
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(BusinessItems));
                using (XmlReader reader = XmlReader.Create(response))
                {
                    businessItems = (BusinessItems) xmlSerializer.Deserialize(reader);
                }
            }
            return View(businessItems);
            }
            else if(output =="xml")
            {
                //check iformat
                return  this.Content(response, "text/xml");
            }
            else if(output =="json")
            {
                //check iformat
                return Json(response);
            }
            else
            {
                return View(response);
            }
        }
    }
}
