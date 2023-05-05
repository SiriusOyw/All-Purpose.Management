using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using Zhaoxi.Manage.BusinessInterface;
using Zhaoxi.Manage.Common.Extensions;
using Zhaoxi.Manage.Common.Result;
using Zhaoxi.Manage.MentApi.Utility.Filters;
using Zhaoxi.Manage.MentApi.Utility.InitDatabaseExt;
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
    [ExceptionFilter]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ApiVersions.V1))]
    [Function(MuType.Page,"用户管理")]
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
        [Function(MuType.Btn,"查询用户")]
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
            return await Task.FromResult(new JsonResult(result));
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateParaFilter]
        public async Task<JsonResult> AddUser([FromServices] IUserManagerService userManagerService, [FromServices] IMapper mapper, SysUserDTO userDTO)
        {
            //对于数据在添加之前
            //参数的校验
            //if (true)
            //{
            //}

            //可以通过actionFilter扩展


            var adduser = mapper.Map<Sys_User>(userDTO);
            //adduser.Password=
            userManagerService.Insert(adduser);
            var result = new JsonResult(new ApiDataResult<SysUserDTO>()
            {
                Data = mapper.Map<SysUserDTO>(adduser),
                Success = true,
                Message = "添加用户"
            });
            return await Task.FromResult(result);
        }
    }
}
