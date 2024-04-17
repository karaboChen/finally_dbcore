using Microsoft.AspNetCore.Builder;

namespace finally_dbcore.common
{
    public static class Errormiddle
    {
        public static IApplicationBuilder 錯誤攔截(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Handlerror>();
        }
    }

}
