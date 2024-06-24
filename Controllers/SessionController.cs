using Bills.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bills.Controllers
{
    public class SessionController : Controller
    {
        public string sessionApiURL = "https://whatson-api.parliament.uk/calendar/sessions/list.json";
        public async Task<IActionResult> GetAllSessions()
        {
            WhatsOnCalendarApiService calendarApiService = new WhatsOnCalendarApiService();
            var sessions = await calendarApiService.GetSessionsBills();
            return View(sessions);
        }
    }
}
