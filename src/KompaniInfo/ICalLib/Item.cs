using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalLib
{
  public class Item
  {
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public bool IsAllDay { get { return StartDate == EndDate || StartDate.Date != EndDate.Date; } }
  }
}
