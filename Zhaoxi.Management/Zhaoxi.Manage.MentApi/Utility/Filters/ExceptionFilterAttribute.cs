using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Zhaoxi.Manage.Common.Result;

namespace Zhaoxi.Manage.MentApi.Utility.Filters
{
    public class ExceptionFilterAttribute : Attribute, IAsyncExceptionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                context.Result = new JsonResult(new ApiDataResult<string>
                {
                    Success = false,
                    Message = context.Exception.Message
                });
            }
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
