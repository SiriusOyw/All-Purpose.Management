using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using Zhaoxi.Manage.BusinessInterface;
using Zhaoxi.Manage.Common.Extensions;
using Zhaoxi.Manage.Common.Result;
using Zhaoxi.Manage.MentApi.Utility.SwaggerExt;
using Zhaoxi.Manage.Models.DTO;
using Zhaoxi.Manage.Models.Entity;

namespace Zhaoxi.Manage.MentApi.Controllers.SystemApi
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ApiVersions.V1))]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 用户信息的分页查询
        /// </summary>
        /// <param name="userManagerService"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchaString"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{pageIndex:int}/{pageSize:int}/{searchaString}")]
        [Route("{pageIndex:int}/{pageSize:int}")]
        public async Task<JsonResult> GetUserPage([FromServices] IUserManagerService userManagerService, [FromServices] IMapper mapper, int pageIndex, int pageSize, string? searchaString = null)
        {
            Expressionable<Sys_User> expressionable = new Expressionable<Sys_User>();
            expressionable.AndIF(!searchaString.IsNullOrWhiteSpace(), u => u.Name.Contains(searchaString));
            PagingData<Sys_User> paging = userManagerService.QueryPage<Sys_User>(expressionable.ToExpression(), pageSize, pageIndex, c => c.LastLoginTime, false);

            ApiDataResult<PagingData<SysUserDTO>> result = new ApiDataResult<PagingData<SysUserDTO>>()
            {
                Data = mapper.Map<PagingData<SysUserDTO>>(paging),
                Success = true,
                Message = "用户分页查询"
            };
            return new JsonResult(result);
        }
    }
}
