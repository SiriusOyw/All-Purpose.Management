using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using Zhaoxi.Manage.Common.Result;
using Zhaoxi.Manage.Common.ValidateRules;
using Zhaoxi.Manage.Models.DTO;

namespace Zhaoxi.Manage.MentApi.Utility.Filters
{
    /// <summary>
    /// 参数校验
    /// </summary>
    public class ValidateParaAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //这里是验证的业务逻辑--验证参数
            List<object?> parameterList = context.ActionArguments
                .Where(p => p.Value is BaseDTO && p.Value is not null)
                .Select(c => c.Value)
                .ToList();

            List<(bool, string?)> messagelist = new List<(bool, string?)>();

            foreach (var parameter in parameterList)
            {
                //实体验证的实现--通过特性
                foreach (var prop in parameter.GetType().GetProperties().Where(p => p.IsDefined(typeof(BaseAbstractAttribute), true)))
                {
                    BaseAbstractAttribute? attribute = prop.GetCustomAttribute<BaseAbstractAttribute>();
                    messagelist.Add(attribute.DoValidate(prop.GetValue(parameter)));
                }
            }

            if (messagelist.Any(c => c.Item1 == false))
            {
                context.Result = new JsonResult(new ApiDataResult<string>()
                {
                    Success = false,
                    Message = string.Join(",", messagelist.Where(c => c.Item1 == false).Select(c => c.Item2))
                });
            }
            else
            {
                await next();
            }
        }
    }
}
