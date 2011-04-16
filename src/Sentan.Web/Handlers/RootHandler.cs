using tinyweb.framework;
using tinyweb.viewengine.spark;

namespace Sentan.Web.Handlers
{
    public class RootHandler
    {
        public IHandlerResult Get()
        {
            return View.Spark("Views/Index.spark", "Master.spark");
        }
    }
}