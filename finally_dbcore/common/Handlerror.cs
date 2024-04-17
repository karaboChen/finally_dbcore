using System.Text;

namespace finally_dbcore.common
{
    public class Handlerror
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<Handlerror> _logger;

        public Handlerror(RequestDelegate next, ILogger<Handlerror> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task 擷取訊息(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                //建立log資訊
                var message = new StringBuilder();
                message.AppendLine("例外類型: "+e.GetType().Name);
                message.AppendLine("例外訊息: " + e.Message);
                message.AppendLine("例外來源: " + e.Source);
                message.AppendLine("Stack Trace: " + e.StackTrace);
                message.AppendLine("TargetSite: " + e.TargetSite);
            }
        }

    }
}
