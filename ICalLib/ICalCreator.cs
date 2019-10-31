using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Ical.Net;
using Ical.Net.Serialization;

namespace ICalLib
{
  public static class ICalCreator
  {
    public static byte[] CreateIcal()
    {
      var iCal = new Calendar();
      var wEuropeST = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
      iCal.AddTimeZone(wEuropeST);
      WebClient webClient = new WebClient();
      webClient.Encoding = Encoding.UTF8;
      string[] items = webClient.DownloadString("http://hvmkblg.github.io/ross/ross.txt" + "?ticks=" + DateTime.Now.Ticks.ToString()).Split('$');

      foreach (string item in items)
      {
        if (items.Length == 0)
          continue;
        var parsedItem = ItemBL.CreateItem(item);
        if (parsedItem != null)
          iCal.Events.Add(ItemBL.ToEvent(parsedItem));
      }

      var serializer = new CalendarSerializer();
      string result = serializer.SerializeToString(iCal);

      byte[] bytes = Encoding.UTF8.GetBytes(result);

      return bytes;
    }


  }
}
