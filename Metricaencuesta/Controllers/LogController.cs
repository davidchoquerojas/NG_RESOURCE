using Metricaencuesta.Utils;
using System.Web.Mvc;

namespace Metricaencuesta.Controllers
{
    [SessionValidator]
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index(string id)
        {
            return new LogResult(id);
        }
    }
}