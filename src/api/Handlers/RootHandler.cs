using tinyweb.framework;
using tinyweb.viewengine.spark;

namespace Sentan.Web.Handlers
{
    public class RootHandler
    {
        public IResult Post(string text)
        {
            var model = Analyser.Analyse(text);
			
			return Result.Json(model);
        }
    }
}