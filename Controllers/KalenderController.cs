using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ICalLib;

namespace KalenderWeb.Controllers
{
  [AllowAnonymous]
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