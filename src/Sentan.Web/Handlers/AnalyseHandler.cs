using tinyweb.framework;
using tinyweb.viewengine.spark;

namespace Sentan.Web.Handlers
{
    public class AnalyseHandler
    {
        public IHandlerResult Post(string text)
        {
            var model = Analyser.Analyse(text);
            return View.Spark(model, "Views/Results.spark", "Master.spark");
        }
    }
}