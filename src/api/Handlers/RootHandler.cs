using tinyweb.framework;

namespace Sentimentalizer.Api.Handlers
{
    public class RootHandler
    {
        public IResult Get(string text)
        {
            var model = Analyser.Analyse(text);
			return Result.Json(model);
        }
    }
}