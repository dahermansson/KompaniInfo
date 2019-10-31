using Microsoft.AspNetCore.Mvc;
using ICalLib;

namespace KalenderWeb.Controllers
{
  public class KalenderController : Controller
  {
    // GET: Kalender
    [ResponseCache(Duration = 0)]
    public ActionResult Index()
    {
      var bytes = ICalCreator.CreateIcal();
      var contentType = "text/calendar";
      return File(bytes, contentType, "hmvmkblg.ical");
    }
  }
}